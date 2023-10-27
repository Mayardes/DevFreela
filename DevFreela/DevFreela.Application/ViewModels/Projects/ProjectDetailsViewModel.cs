namespace DevFreela.Application.ViewModels;

public class ProjectDetailsViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishAt { get; set; }
    public decimal TotalCost { get; set; }
}