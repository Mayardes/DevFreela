namespace DevFreela.Application.InputModels.Project;

public class CreateCommentInputModel
{
    public string Content { get; set; }
    public Guid IdProject { get; set; }
    public Guid IdUser { get; set; }
    public DateTime CreatedAt { get; set; }
}