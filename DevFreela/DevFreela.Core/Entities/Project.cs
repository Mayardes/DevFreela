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
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid IdClient { get; set; }
    public User Client { get; set; }
    public Guid IdFreelancer { get; set; }
    public User Freelancer { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishAt { get; set; }
    public ProjectStatusEnum Status { get; set; }
    public List<ProjectComment> Comments { get; set; }
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