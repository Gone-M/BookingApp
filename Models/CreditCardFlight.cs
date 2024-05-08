using System;
using System.ComponentModel.DataAnnotations;

namespace booking.Models
{
	public class CreditCardFlight
	{
        [Key]
        public int CreditCardFlightId { get; set; }

        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        [Required]
        public string DepartureAirport { get; set; }

        [Required]
        public string ArrivalAirport { get; set; }

        [Required]
        public string Airline { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}

