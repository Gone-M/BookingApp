using System;
using System.Linq;
using booking.Models;
using Microsoft.AspNetCore.Mvc;
using booking.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingDbContext _context;

        public BookingController(BookingDbContext context)
        {
            _context = context;
        }

        public IActionResult Cars(string pickupLocation, DateTime pickupDate)
        {
            var pickupLocations = _context.Cars
                .Select(c => c.PickupLocation)
                .Distinct()
                .ToList();

            ViewBag.PickupLocations = pickupLocations;

            var availableCars = _context.Cars
                .Where(c => c.PickupLocation == pickupLocation && c.PickupDate.Date == pickupDate.Date)
                .ToList();

            ViewBag.CarDetails = availableCars.FirstOrDefault();
            ViewBag.PickupLocation = pickupLocation;
            ViewBag.PickupDate = pickupDate;

            return View(availableCars);
        }


        public IActionResult Flights(string departureAirport, string arrivalAirport, DateTime departureDate)
        {
            var filteredFlights = _context.Flights
                .Where(f => f.DepartureAirport == departureAirport
                         && f.ArrivalAirport == arrivalAirport
                         && f.DepartureTime.Date == departureDate.Date)
                .ToList();

            return View(filteredFlights);
        }


        public IActionResult Hotels(string location, DateTime checkInDate, DateTime checkOutDate)
        {
            IQueryable<Hotel> filteredHotels = _context.Hotels;

            if (!string.IsNullOrEmpty(location))
            {
                filteredHotels = filteredHotels.Where(h => h.Location.Contains(location));
            }

            filteredHotels = filteredHotels.Where(h =>
                h.CheckInDate.Date <= checkOutDate.Date &&
                h.CheckOutDate.Date >= checkInDate.Date);

            var availableCars = _context.Cars
                .Where(c => c.PickupLocation == location && c.PickupDate.Date == checkInDate.Date)
                .ToList();

            var availableFlights = _context.Flights
                .Where(f => f.DepartureAirport == location && f.DepartureTime.Date == checkInDate.Date)
                .ToList();

            int numberOfNights = (int)(checkOutDate - checkInDate).TotalDays;
            foreach (var hotel in filteredHotels)
            {
                hotel.PricePerNight *= numberOfNights;
            }

            ViewBag.Locations = _context.Hotels.Select(h => h.Location).Distinct().ToList();
            ViewBag.NumberOfNights = numberOfNights;

            ViewBag.AvailableCars = availableCars;
            ViewBag.AvailableFlights = availableFlights;

            return View(filteredHotels.ToList());
        }


        public IActionResult CreditCard(int carId)
        {
            var car = _context.Cars.FirstOrDefault(c => c.CarId == carId);

            if (car == null)
            {
                return NotFound();
            }

            ViewBag.CarModel = car.CarModel;
            ViewBag.PickupLocation = car.PickupLocation;
            ViewBag.Price = car.Price;

            return View();
        }

        [HttpPost]
        public IActionResult CreditCard(CreditCard model)
        {
            if (ModelState.IsValid)
            {
                _context.CreditCard.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult CreditCardFlight(int flightId)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.FlightId == flightId);

            if (flight == null)
            {
                return NotFound();
            }

            ViewBag.Airline = flight.Airline;
            ViewBag.DepartureAirport = flight.DepartureAirport;
            ViewBag.ArrivalAirport = flight.ArrivalAirport;
            ViewBag.Price = flight.Price;

            return View();
        }


        [HttpPost]
        public IActionResult CreditCardFlight(CreditCardFlight model)
        {
            if (ModelState.IsValid)
            {
                _context.CreditCardFlight.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }


        public IActionResult CreditCardHotel(int hotelId)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.HotelId == hotelId);

            if (hotel == null)
            {
                return NotFound();
            }

            ViewBag.HotelId = hotel.HotelId;
            ViewBag.HotelName = hotel.HotelName;
            ViewBag.Location = hotel.Location;
            ViewBag.PricePerNight = hotel.PricePerNight;
            ViewBag.CheckInDate = hotel.CheckInDate;
            ViewBag.CheckOutDate = hotel.CheckOutDate;

            return View();
        }


        [HttpPost]
        public IActionResult CreditCardHotel(CreditCardHotel model)
        {
            if (ModelState.IsValid)
            {
                _context.CreditCardHotel.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }




    }
}
