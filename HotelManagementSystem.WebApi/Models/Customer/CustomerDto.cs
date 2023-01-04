using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.WebApi.Models.Customer
{
    public class CustomerDto
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string IdProof { get; set; }
        public string AddressProof { get; set; }
        public string PhoneNo { get; set; }
        public string ProfileImage { get; set; }
    }
}
