using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.WebApi.Models.RoomTypeModel
{
    public class RoomTypeDto
    {
        public string RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public string RoomImg { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
