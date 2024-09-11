namespace HotelManagement.Core.Repositories;
public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(int id);
    Task<IQueryable<TEntity>> GetAllAsync();
}
