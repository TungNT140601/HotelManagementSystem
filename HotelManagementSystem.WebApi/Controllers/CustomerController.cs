using HotelManagementSystem.WebApi.DatabaseContext;
using HotelManagementSystem.WebApi.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private readonly HotelManagementDBContext dBContext;
        private readonly ICustomerService customerService;
        public CustomerController(HotelManagementDBContext managementDBContext,
             ICustomerService _customerService)
        {
            dBContext = managementDBContext;
            customerService = _customerService;
        }
        [HttpPost]
        public async Task<Dictionary<string, object>> LoginCheck(string username, string password)
        {
            return await customerService.LoginCheck(username, password);
        }
    }
}
