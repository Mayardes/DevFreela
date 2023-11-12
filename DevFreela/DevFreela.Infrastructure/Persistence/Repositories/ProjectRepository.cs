using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaDbContext _context;
    
    public ProjectRepository(DevFreelaDbContext context)
    {
        _context = context;
    }
    public async Task<Project> GetByIdAsync(Guid id)
    {
        return await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Project>> GetAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Guid> AddAsync(Project model)
    {
        await _context.Projects.AddAsync(model);
        return model.Id;
    }

    public async Task<Guid> UpdateAsync(Guid id, Project model)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is not null)
            _context.Projects.Update(model);
        return id;
    }

    public async Task RemoveAsync(Guid id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is not null)
            _context.Projects.Remove(project);
    }
}