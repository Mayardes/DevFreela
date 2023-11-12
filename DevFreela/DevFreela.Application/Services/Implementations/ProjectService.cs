using DevFreela.Application.InputModels.Project;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _dbcontext;

    public ProjectService(DevFreelaDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    public Guid Create(CreateProjectInputModel model)
    {
        var project = new Project(model.Name, model.Title, model.Description, model.IdClient, model.IdFreelancer, model.TotalCost);
        _dbcontext.Projects.Add(project);

        return project.Id;
    }
    
    public void CreateComment(CreateCommentInputModel model)
    {
        var comments = new ProjectComment(model.Content, model.IdProject, model.IdUser);
        _dbcontext.ProjectComments.Add(comments);
    }
    public void Delete(Guid id)
    {
        var project = _dbcontext.Projects.First(x => x.Id == id) ?? throw new Exception("Not find a project");
        project.SetStatusCancelled();
    }
    public ICollection<ProjectViewModel> GetAll(string queryString)
    {
        return _dbcontext.Projects.Select(x => new ProjectViewModel(x.Id, x.Title, x.CreatedAt)).ToList();
    }
    public ProjectDetailsViewModel GetById(Guid id)
    {
        var project = _dbcontext.Projects.SingleOrDefault(x => x.Id == id) 
                      ?? throw new Exception("Project not found");

        return new ProjectDetailsViewModel()
        {
            Id = project.Id,
            Description = project.Description,
            Title = project.Title,
            StartedAt = project.StartedAt,
            TotalCost = project.TotalCost,
            FinishAt = project.FinishAt
        };
    }
    public void Finish(Guid id)
    {
        var project = _dbcontext.Projects.First(x => x.Id == id)
                      ?? throw new Exception("Project not found.");
        
        project.SetStatusFinish();
    }
    public void Start(Guid id)
    {
        var project = _dbcontext.Projects.First(x => x.Id == id)
                      ?? throw new Exception("Project not found.");
        project.SetStatusStarted();
    }
    public void Update(UpdateProjectInputModel model)
    {
        var project = _dbcontext.Projects.Find(model.Id)
                      ?? throw new Exception("Project not found.");

        project.Update(title: project.Title, description: model.Description, totalCost: project.TotalCost);
    }
}