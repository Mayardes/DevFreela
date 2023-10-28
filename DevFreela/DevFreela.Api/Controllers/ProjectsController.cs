using DevFreela.Api.Models;
using DevFreela.Application.InputModels.Project;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.Api.Controllers;

[Route("v1/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpGet("")]
    public IActionResult Get(string queryString)
    {
        var project = _projectService.GetAll(queryString);
        return Ok(project);
    }

    [HttpGet("{id:Guid}")]
    public IActionResult GetById(Guid id)
    {
        var project = _projectService.GetById(id);
        return Ok(project);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectInputModel model)
    {
        var id = _projectService.Create(model);
        return Created("GetById", id);
    }

    [HttpPut("{id:Guid}")]
    public IActionResult Put([FromBody] UpdateProjectInputModel model, Guid id)
    {
        model.SetId(id);
        _projectService.Update(model);
        
        var routeValues = new
        {
            id
        };
        return CreatedAtAction(nameof(GetById),routeValues, model);
    }

    [HttpDelete("{id:Guid}")]
    public IActionResult Delete(Guid id)
    {
        _projectService.Delete(id);
        return NoContent();
    }

    [HttpPost("id:guid")]
    public IActionResult PostComment(Guid id, [FromBody] CreateCommentInputModel model)
    {
        _projectService.CreateComment(model);
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(Guid id)
    {
        _projectService.Start(id);
        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public IActionResult Finish(Guid id)
    {
        _projectService.Finish(id);
        return NoContent();
    }
    
}