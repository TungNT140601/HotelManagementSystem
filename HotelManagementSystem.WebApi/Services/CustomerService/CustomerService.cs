using HotelManagementSystem.WebApi.DatabaseContext;
using HotelManagementSystem.WebApi.Models.Customer;

namespace HotelManagementSystem.WebApi.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly HotelManagementDBContext dBContext;
        public CustomerService(HotelManagementDBContext hotelManagement)
        {
            dBContext = hotelManagement;
        }
        public async Task<Dictionary<string, object>> LoginCheck(string username, string password)
        {
            try
            {
                var cus = dBContext.Customers.Where(x => x.Username == username).FirstOrDefault();
                if (cus != null)
                {
                    if (cus.Password == password)
                    {
                        return new Dictionary<string, object>() { {"Ok", new CustomerDto
                        {
                            Address = cus.Address,
                            AddressProof = cus.AddressProof,
                            CustomerId = cus.CustomerId,
                            CustomerName = cus.CustomerName,
                            Gender = cus.Gender,
                            IdProof = cus.IdProof,
                            PhoneNo = cus.PhoneNo,
                            ProfileImage = cus.ProfileImage,
                        }
                    } };
                    }
                    else
                    {
                        return new Dictionary<string, object>() { { "Error", new { errMsg = "Password was wrong!!!" } } };
                    }
                }
                else
                {
                    return new Dictionary<string, object>() { { "Error", new { errMsg = "Username not exist!!!" } } };
                }
            }catch(Exception ex)
            {
                return new Dictionary<string, object>() { { "Error 500", new { errMsg = ex.Message } } };
            }
        }
    }
}
