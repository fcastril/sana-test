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
        public CustomerController(ICustomerRepository repository) : base(repository)
        {
        }

        [HttpGet("document/{document}")]
        public async Task<IActionResult> GetByDocument(string document)
        {
            try
            {
                return Ok(await _repository.FirstOrDefautlBy(c=>c.Document == document));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
