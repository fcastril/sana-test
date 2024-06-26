﻿using Microsoft.AspNetCore.Mvc;
using Sana.Backend.Api.Controllers.Base;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;

namespace Sana.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController<OrderPpal>
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository repository) : base(repository)
        {
            _orderRepository = repository;
        }

        [HttpGet("document/{document}")]
        public async Task<IActionResult> GetByDocument(string document)
        {
            try
            {
                return Ok(await _orderRepository.GetOrderByDocument(document));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
