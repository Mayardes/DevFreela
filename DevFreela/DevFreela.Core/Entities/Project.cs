using System.Diagnostics;
using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities;

public class Project : BaseEntity
{
    public Project(string name, string title, string description, Guid idClient, Guid idFreelancer, decimal totalCost)
    {
        Id = Guid.NewGuid();
        Name = name;
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;

        CreatedAt = DateTime.Now;
        Comments = new List<ProjectComment>();
        Status = ProjectStatusEnum.Created;
        Comments = new List<ProjectComment>();
    }

    public void Update(string title, string description, decimal totalCost)
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
    public string Name { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Guid IdClient { get; private set; }
    public Guid IdFreelancer { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public List<ProjectComment> Comments { get; private set; }


    public void SetStatus(ProjectStatusEnum projectEnum)
    {
        Status = projectEnum;
    }
    public void SetStatusCancelled()
    {
        if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Started)
            Status = ProjectStatusEnum.Cancelled;
        else
            throw new Exception("currently status must be InProgress or Started");
    }
    public void SetStatusFinish()
    {
        if (Status == ProjectStatusEnum.InProgress)
        {
            Status = ProjectStatusEnum.Finished;
            FinishAt = DateTime.Now;
        }
        else
            throw new Exception("Currenty status must be InProgress!");
    }
    public void SetStatusStarted()
    {
        if (Status == ProjectStatusEnum.Created)
        {
            Status = ProjectStatusEnum.Started;
            StartedAt = DateTime.Now;
        }
        else
            throw new Exception("Currently status must be Created");
    }
}