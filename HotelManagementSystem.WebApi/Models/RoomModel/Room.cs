using HotelManagementSystem.WebApi.Models.BookingModel;
using HotelManagementSystem.WebApi.Models.RoomTypeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.WebApi.Models.RoomModel
{
    public class Room
    {
        [Key]
        [Required]
        public string RoomId { get; set; }
        [Required]
        public string RoomTypeId { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [ForeignKey("RoomTypeId")]
        public RoomType RoomType { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
