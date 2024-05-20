using Microsoft.EntityFrameworkCore;
using Sana.Backend.Domain.Common;
using Sana.Backend.Domain.Entities;
using Sana.Backend.Domain.Port;
using Sana.Backend.Domain.Port.Base;
using Sana.Backend.Infrastructure.Repositories.Base;
using System.Linq;
using System.Linq.Expressions;

namespace Sana.Backend.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, IRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IMainContext mainContext) : base(mainContext)
        {

        }
        public override async Task<Category> GetById(Guid id)
            => await entity
               .Include(p => p.Products)
               .Where(c => c.Id == id)
               .FirstOrDefaultAsync() ?? new();

        public override async Task<List<Category>> ToList() => await entity.Include(p => p.Products).ToListAsync();

        public override async Task<List<Category>> ToListBy(Expression<Func<Category, bool>> expression)
            =>await entity.Where(expression).Include(p=>p.Products).ToListAsync();

        public override async Task<Paginate<Category>> Paginate(int pagina, int tamaño)
            => await Paginator<Category>.Paginate(entity.AsQueryable(), pagina, tamaño);

        public override async Task<Paginate<Category>> Paginate(Paginate<Category> paginadoDto)
        {
            IQueryable<Category> Listabase;
            if (paginadoDto.Filters != null && paginadoDto.Filters.Count > 0)
            {
                Listabase = ConfigurateFilters(entity, paginadoDto);

            }
            else
            {
                Listabase = entity.Include(p=>p.Products).AsQueryable<Category>();
            }

            return await Paginator<Category>.Paginate(Listabase, paginadoDto.Page, paginadoDto.Count);
        }
    }
}
