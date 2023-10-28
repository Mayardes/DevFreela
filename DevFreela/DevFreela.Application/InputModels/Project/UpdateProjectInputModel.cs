namespace DevFreela.Application.InputModels.Project;

public class UpdateProjectInputModel
{
    public Guid Id { get; private set; }
    public string Description { get; set; }

    public void SetId(Guid id)
    {
        Id = id;
    }
}