using HotelManagement.Core.Repositories;
using System.Linq.Expressions;

namespace HotelManagement.Data.Repositories;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public TEntity Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}
