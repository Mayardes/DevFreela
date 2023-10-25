using DevFreela.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.Api.Controllers;

[Route("v1/projects")]
public class ProjectsController : ControllerBase
{
    
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
    public IActionResult Post([FromBody] CreateProjectModel model)
    {
        return Created("GetById", model.Id);
    }

    [HttpPut("{id:Guid}")]
    public IActionResult Put([FromBody] UpdateProjectModel model, Guid id)
    {
        var routeValues = new
        {
            id
        };
        return CreatedAtAction(nameof(GetById),routeValues, model);
    }

    [HttpDelete("{id:Guid}")]
    public IActionResult Delete(Guid id)
    {
        return NoContent();
    }
}