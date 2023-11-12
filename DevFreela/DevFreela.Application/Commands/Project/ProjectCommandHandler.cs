using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Project;

public class ProjectCommandHandler : IRequestHandler<ProjectCommand, Guid>
{
    private readonly IProjectRepository _repository;

    public ProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
        
    public Task<Guid> Handle(ProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Core.Entities.Project(request.Name, request.Title, request.Description, request.IdClient, request.IdClient, request.TotalCost);
        return _repository.AddAsync(project);
    }
}