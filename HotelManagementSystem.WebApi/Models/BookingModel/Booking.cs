using HotelManagementSystem.WebApi.Models.CustomerModel;
using HotelManagementSystem.WebApi.Models.RoomModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.WebApi.Models.BookingModel
{
    public class Booking
    {
        [Key]
        [Required]
        public string BookingId { get; set; }
        [Required]
        public string RoomId { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
