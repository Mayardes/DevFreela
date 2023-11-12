using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaDbContext _context;
    private readonly string _connectionString;
    public ProjectRepository(DevFreelaDbContext context, IConfiguration configuration)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("DevFreelaConnectionString");
    }
    public async Task<Project> GetByIdAsync(Guid id)
    {
        return await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Project>> GetAsync()
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            var script = "SELECT Id, Name, Title FROM tb_project";
            return sqlConnection.Query<Project>(script).ToList();
        }
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