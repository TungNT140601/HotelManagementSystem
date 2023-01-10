using HotelManagementSystem.WebApi.Models.BookingModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.WebApi.Models.CustomerModel
{
    public class Customer
    {
        [Key]
        [Required]
        public string CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }
        [Required]
        [MaxLength(50)]
        public string IdProof { get; set; }
        [Required]
        public string AddressProof { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNo { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
