using HotelManagement.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{

    private readonly DbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
