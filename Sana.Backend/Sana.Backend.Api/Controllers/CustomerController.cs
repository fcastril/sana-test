using Microsoft.AspNetCore.Mvc;
using Sana.Backend.Api.Controllers.Base;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;

namespace Sana.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository repository) : base(repository)
        {
            _customerRepository = repository;
        }

        [HttpGet("document/{document}")]
        public async Task<IActionResult> GetByDocument(string document)
        {
            try
            {
                return Ok(await _customerRepository.GetCustomerByDocument(document));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
