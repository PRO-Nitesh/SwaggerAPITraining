using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailShop.Services.Interface;
using OnlineRetailShop.Repository.Entities;
using Microsoft.AspNetCore.Authorization;

namespace OnlineRetailShop.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomerById(Guid customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer customer)
        {
            await _customerService.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { customerId = customer.CustomerId }, customer);
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult> UpdateCustomer(Guid customerId, Customer customer)
        {
            if (customerId != customer.CustomerId)
            {
                return BadRequest("Customer ID mismatch");
            }

            await _customerService.UpdateCustomerAsync(customer);
            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomer(Guid customerId)
        {
            await _customerService.DeleteCustomerAsync(customerId);
            return NoContent();
        }
    }
}
