using MediatR;

namespace DevFreela.Application.Commands.Project;

public class ProjectCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid IdClient { get; set; }
    public Guid IdFreelancer { get; set; }
    public decimal TotalCost { get; set; }
}