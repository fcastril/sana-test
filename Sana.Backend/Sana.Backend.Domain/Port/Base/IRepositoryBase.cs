using Sana.Backend.Domain.Common;
using System.Linq.Expressions;

namespace Sana.Backend.Domain.Port.Base
{
    public interface IRepositoryBase<T>
           where T : class, new()
    {

        Task<T?> GetById(Guid id);

        Task<List<T>?> ToList();

        Task<bool> Delete(Guid id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<List<T>?> ToListBy(Expression<Func<T, bool>> expression);

        Task<T?> FirstOrDefautlBy(Expression<Func<T, bool>> expression);

        Task<Paginate<T>> Paginate(int page, int lenght);

        Task<Paginate<T>> Paginate(Paginate<T> paginateDto);

        Task<bool> Exist(Expression<Func<T, bool>> expression);

    }
}
