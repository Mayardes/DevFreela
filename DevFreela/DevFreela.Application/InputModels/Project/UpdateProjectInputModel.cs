namespace DevFreela.Application.InputModels.Project;

public class UpdateProjectInputModel
{
    public Guid Id { get; set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal TotalCost { get; private set; }
}