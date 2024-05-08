using System;
using System.ComponentModel.DataAnnotations;

namespace booking.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [Required]
        public string HotelName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal PricePerNight { get; set; }

        [Required]
        public bool Availability { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

    }
}

