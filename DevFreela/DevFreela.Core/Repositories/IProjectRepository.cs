using DevFreela.Core.Entities;
namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
    Task<Project> GetByIdAsync(Guid id);
    Task<ICollection<Project>> GetAsync();
    Task<Guid> AddAsync(Project model);
    Task<Guid> UpdateAsync(Guid id, Project model);
    Task RemoveAsync(Guid id);
}