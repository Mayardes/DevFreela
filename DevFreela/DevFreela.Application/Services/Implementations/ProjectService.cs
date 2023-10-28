using System.Diagnostics;
using DevFreela.Application.InputModels.Project;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _dbcontext;
    
    public ProjectService(DevFreelaDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    
    /// <summary>
    /// Create a new Project.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public Guid Create(CreateProjectInputModel model)
    {
        var project = new Project(model.Name, model.Title, model.Description, model.IdClient, model.IdFreelancer, model.TotalCost);
        _dbcontext.Projects.Add(project);

        return project.Id;
    }
    
    /// <summary>
    /// Create a new Comment.
    /// </summary>
    /// <param name="model"></param>
    public void CreateComment(CreateCommentInputModel model)
    {
        var comments = new ProjectComment(model.Content, model.IdProject, model.IdUser);
        _dbcontext.ProjectComments.Add(comments);
    }
    
    /// <summary>
    /// Define status Project as Cancelled.
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(Guid id)
    {
        var project = _dbcontext.Projects.First(x => x.Id == id) ?? throw new Exception("Not find a project");
        project.SetStatusCancelled();
    }
    
    /// <summary>
    /// Get all projects.
    /// </summary>
    /// <param name="queryString"></param>
    /// <returns></returns>
    public ICollection<ProjectViewModel> GetAll(string queryString)
    {
        return _dbcontext.Projects.Select(x => new ProjectViewModel(x.Id, x.Title, x.CreatedAt)).ToList();
    }

    
    /// <summary>
    /// Get a Project.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
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

    /// <summary>
    /// Define a Project as Finished.
    /// </summary>
    /// <param name="id"></param>
    public void Finish(Guid id)
    {
        var project = _dbcontext.Projects.First(x => x.Id == id)
                      ?? throw new Exception("Project not found.");
        
        project.SetStatusFinish();
    }
    
    /// <summary>
    /// Define Status as Started Project.
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Start(Guid id)
    {
        var project = _dbcontext.Projects.First(x => x.Id == id)
                      ?? throw new Exception("Project not found.");
        project.SetStatusStarted();
    }
    
    /// <summary>
    /// Update a project
    /// </summary>
    /// <param name="model"></param>
    public void Update(UpdateProjectInputModel model)
    {
        var project = _dbcontext.Projects.Find(x => x.Id == model.Id)
                      ?? throw new Exception("Project not found.");

        project.Update(title: project.Title, description: model.Description, totalCost: project.TotalCost);
    }
}