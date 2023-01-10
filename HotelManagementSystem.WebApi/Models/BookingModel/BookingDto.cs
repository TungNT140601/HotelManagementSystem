namespace HotelManagementSystem.WebApi.Models.BookingModel
{
    public class BookingDto
    {
        public string BookingId { get; set; }
        public string RoomId { get; set; }
        public string CustomerId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
