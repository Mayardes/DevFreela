using DevFreela.Application.InputModels.Project;
using DevFreela.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Application.Services.Interfaces;

public interface IProjectService
{
    ICollection<ProjectViewModel> GetAll(string queryString);
    ProjectDetailsViewModel GetById(Guid id);
    Guid Create([FromBody] CreateProjectInputModel model);
    void Update([FromBody] UpdateProjectInputModel model);
    void Delete(Guid id);
    void CreateComment(CreateCommentInputModel model);
    void Start(Guid id);
    void Finish(Guid Id);
}