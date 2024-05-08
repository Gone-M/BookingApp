using System;
using System.ComponentModel.DataAnnotations;

namespace booking.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The Username field is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string Address { get; set; }
        public string Bio { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

