using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Project;

public class ProjectCommandHandler : IRequestHandler<ProjectCommand, Guid>
{
    private readonly IProjectRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public ProjectCommandHandler(IProjectRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
        
    public Task<Guid> Handle(ProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Core.Entities.Project(request.Name, request.Title, request.Description, request.IdClient, request.IdClient, request.TotalCost); 
        
        var result =_repository.AddAsync(project);
        _unitOfWork.SaveChangesAsync();

        return result;
    }
}