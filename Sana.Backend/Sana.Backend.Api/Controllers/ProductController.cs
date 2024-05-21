using Microsoft.AspNetCore.Mvc;
using Sana.Backend.Api.Controllers.Base;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;

namespace Sana.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<Product>
    {
        public ProductController(IProductRepository repository) : base(repository)
        {
        }
    }
}
