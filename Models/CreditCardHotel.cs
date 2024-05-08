using System;
using System.ComponentModel.DataAnnotations;

namespace booking.Models
{
	public class CreditCardHotel
	{
        [Key]
        public int CreditCardHotelId { get; set; }

        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        [Required]
        public string HotelName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal PricePerNight { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }
    }
}

