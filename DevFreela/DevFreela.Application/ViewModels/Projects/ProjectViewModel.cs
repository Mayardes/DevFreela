using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Application.ViewModels;

public class ProjectViewModel
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid IdClient { get; set; }
    public Guid IdFreelancer { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishAt { get; set; }
    public ProjectStatusEnum Status { get; set; }
    public List<ProjectComment> Comments { get; set; }
}