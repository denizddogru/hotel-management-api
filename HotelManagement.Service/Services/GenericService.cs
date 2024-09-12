using HotelManagement.Core.Dtos;
using HotelManagement.Core.Services;
using SharedLibrary.Dtos;
using System.Linq.Expressions;

namespace HotelManagement.Service.Services;
public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
{
    public Task<Response<TDto>> AddAsync(TDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<Response<IEnumerable<TDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<TDto>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<NoDataDto>> Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TDto, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}
