using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.WebApi.Models.CustomerModel
{
    public class CustomerInput
    {
        public string CustomerId { get; set; } = null;
        public string CustomerName { get; set; } = null;
        public string Username { get; set; } = null;
        public string Password { get; set; } = null;
        public string Address { get; set; } = null;
        public string Gender { get; set; } = null;
        public string IdProof { get; set; } = null;
        public string AddressProof { get; set; } = null;
        public string PhoneNo { get; set; } = null;
        public string ProfileImage { get; set; } = null;
    }
}
