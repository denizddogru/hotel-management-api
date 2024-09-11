namespace HotelManagement.Core.UnitOfWork;
public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync();
}
