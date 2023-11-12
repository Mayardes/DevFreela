using DevFreela.Application.Commands.Project;
using DevFreela.Application.InputModels.Project;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers;

[Route("v1/projects")]
public class ProjectsController : ControllerBase
{
    private readonly ISender _mediator;
    public ProjectsController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("")]
    public IActionResult Get(string queryString)
    {
        return Ok();
    }

    [HttpGet("{id:Guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] ProjectCommand model)
    {
        var result =_mediator.Send(model);
        return Created("GetById", Guid.NewGuid());
    }

    [HttpPut("{id:Guid}")]
    public IActionResult Put([FromBody] UpdateProjectInputModel model, Guid id)
    {
     
        //return CreatedAtAction(nameof(GetById),routeValues, model);
        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    public IActionResult Delete(Guid id)
    {
        return NoContent();
    }

    [HttpPost("id:guid")]
    public IActionResult PostComment(Guid id, [FromBody] CreateCommentInputModel model)
    {
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(Guid id)
    {
        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public IActionResult Finish(Guid id)
    {
        return NoContent();
    }
    
}