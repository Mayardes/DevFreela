namespace DevFreela.Application.InputModels.Project;

public class CreateProjectInputModel
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid IdClient { get; set; }
    public Guid IdFreelancer { get; set; }
    public decimal TotalCost { get; set; }
}