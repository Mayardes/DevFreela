using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.Skill;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _dbContext;
    
    public SkillService(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<SkillViewModel> GetAll()
    {
       return _dbContext.Skills.Select(p => new SkillViewModel()
            { Id = p.Id, Description = p.Description, IdProject = p.Id }).ToList();
    }
}