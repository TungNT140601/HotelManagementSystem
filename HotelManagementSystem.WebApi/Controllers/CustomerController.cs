using HotelManagementSystem.WebApi.DatabaseContext;
using HotelManagementSystem.WebApi.Models.CustomerModel;
using HotelManagementSystem.WebApi.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<Dictionary<string, object>> LoginCheck(CustomerInput input)
        {
            return await customerService.LoginCheck(input.Username, input.Password);
        }
        [HttpGet]
        public async Task<Dictionary<string, object>> GetCustomerById([Required] string id)
        {
            return await customerService.GetCustomerById(id);
        }
        [HttpGet]
        public async Task<Dictionary<string, object>> GetCustomers()
        {
            return await customerService.GetCustomers();
        }
        [HttpPost]
        public async Task<Dictionary<string, object>> CreateOrUpdateCustomer(CustomerInput input)
        {
            return await customerService.CreateOrUpdateCustomer(input);
        }
        [HttpDelete]
        public async Task<Dictionary<string, object>> DeleteCustomer([Required] string? customerId)
        {
            return await customerService.DeleteCustomer(customerId);
        }

    }
}
