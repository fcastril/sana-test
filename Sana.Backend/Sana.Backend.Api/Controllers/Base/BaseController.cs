using Microsoft.AspNetCore.Mvc;
using Sana.Backend.Domain.Common;
using Sana.Backend.Domain.Port.Base;

namespace Sana.Backend.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract partial class BaseController<ENT> : Controller
        where ENT : BaseEntity, new()
    {
        protected readonly IRepositoryBase<ENT> _repository;

        protected BaseController(IRepositoryBase<ENT> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ENT ent)
        {
            try
            {
                return Ok(await _repository.Create(ent));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }

        }

        [HttpPut]
        public async Task<IActionResult> Update(ENT ent)
        {
            try
            {
                return Ok(await _repository.Update(ent));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repository.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _repository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _repository.Delete(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPost("paginator")]
        public async Task<IActionResult> Paginator(Paginate<ENT> paginate)
        {
            try
            {
                return Ok(await _repository.Paginate(paginate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("paginator/page/{page}/lenght/{lenght}")]
        public async Task<IActionResult> PaginatorPage(int page, int lenght)
        {
            try
            {
                return Ok(await _repository.Paginate(page, lenght));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }




    }
}
