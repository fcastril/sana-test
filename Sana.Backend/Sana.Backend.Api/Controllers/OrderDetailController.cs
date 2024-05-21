using Microsoft.AspNetCore.Mvc;
using Sana.Backend.Api.Controllers.Base;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;

namespace Sana.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : BaseController<OrderDetail>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailController(IOrderDetailRepository repository) : base(repository)
        {
            _orderDetailRepository = repository;
        }

        [HttpGet("OrderId/{Id}")]
        public async Task<IActionResult> GetByOrderId(Guid Id)
        {
            try
            {
                return Ok(await _orderDetailRepository.GetByOrderId(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
