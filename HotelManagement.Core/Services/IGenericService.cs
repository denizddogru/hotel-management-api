using SharedLibrary.Dtos;
using System.Linq.Expressions;

namespace HotelManagement.Core.Services;
public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class
{
    Task<Response<TDto>> GetByIdAsync(int id);
    Task<Response<IEnumerable<TDto>>> GetAllAsync();
    Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TDto, bool>> predicate);
    Task<Response<TDto>> AddAsync(TDto entity);
    Task<Response<NoDataDto>> Remove(int id);
}
