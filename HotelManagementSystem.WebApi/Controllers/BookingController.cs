using HotelManagementSystem.WebApi.Models.BookingModel;
using HotelManagementSystem.WebApi.Services.BookingService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController
    {
        private readonly IBookingService bookingService;
        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        [HttpGet]
        public Task<Dictionary<string, object>> GetBookings()
        {
            return bookingService.GetBookings();
        }
        [HttpGet]
        public Task<Dictionary<string, object>> GetBookingById([Required] string id)
        {
            return bookingService.GetBookingById(id);
        }
        [HttpPost]
        public Task<Dictionary<string, object>> CreateOrUpdateBooking(BookingDto input)
        {
            return bookingService.CreateOrUpdateBooking(input);
        }
        [HttpDelete]
        public Task<Dictionary<string, object>> DeleteBooking([Required] string id)
        {
            return bookingService.DeleteBooking(id);
        }
    }
}
