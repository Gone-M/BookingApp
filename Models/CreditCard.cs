using System;
using System.ComponentModel.DataAnnotations;

namespace booking.Models
{
    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }

        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        [Required]
        public string CarModel { get; set; }

        [Required]
        public string PickupLocation { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
