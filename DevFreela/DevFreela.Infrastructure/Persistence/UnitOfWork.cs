using DevFreela.Infrastructure.Persistence.Repositories;

namespace DevFreela.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly DevFreelaDbContext _context;
   
    public UnitOfWork(DevFreelaDbContext context)
    {
        _context = context;
    }
   
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}