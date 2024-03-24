using AutomapperPlayground.DTO;
using AutomapperPlayground.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutomapperPlayground.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CustomerListResponse>), 200)]
        public async Task<IActionResult> GetCustomerList()
        {
            var customers = await _customerService.GetCustomerList();

            return Ok(customers);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CustomerDetailResponse), 200)]
        public async Task<IActionResult> GetCustomerDetails(int id)
        {
            var customer = await _customerService.GetCustomerDetails(id);

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerCreateResponse), 200)]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateRequest request)
        {
            var response = await _customerService.CreateCustomer(request);

            return Ok(response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(CustomerUpdateResponse), 200)]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerUpdateRequest request)
        {
            var response = await _customerService.UpdateCustomer(id, request);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomer(id);

            return Ok();
        }
    }
}
