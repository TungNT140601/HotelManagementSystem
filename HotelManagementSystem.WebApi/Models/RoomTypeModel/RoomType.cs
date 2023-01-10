using HotelManagementSystem.WebApi.Models.RoomModel;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.WebApi.Models.RoomTypeModel
{
    public class RoomType
    {
        [Key]
        [Required]
        public string RoomTypeId { get; set; }
        [Required]
        public string RoomTypeName { get; set; }
        [Required]
        public string RoomImg { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
