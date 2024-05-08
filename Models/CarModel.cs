using System;
using System.ComponentModel.DataAnnotations;

namespace booking.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Required]
        public string PickupLocation { get; set; }

        [Required]
        public DateTime PickupDate { get; set; }

        [Required]
        public string RentalCompany { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public bool Availability { get; set; }

    }
}
