using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities;

public class Project : BaseEntity
{
    public Project(string name, string title, string description, Guid idClient, Guid idFreelancer, decimal totalCost)
    {
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
}