using DevFreela.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers;

[Route("api/users")]
public class UsersController : ControllerBase
{
    
    [HttpGet("{id:Guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] CreateUserModel model)
    {
        var id = Guid.NewGuid();
        return CreatedAtAction(nameof(GetById), id, model);
    }

    [HttpPost("{id:Guid}/comments")]
    public IActionResult PostComments([FromBody] CreateCommentModel model, Guid id)
    {
        return NoContent();
    }

    [HttpPut("{id:Guid}/start")]
    public IActionResult Start(Guid id)
    {
        return Ok();
    }

    [HttpPut("{id:Guid}")]
    public IActionResult Finish(Guid id)
    {
        return NoContent();
    }

    [HttpPut("{id:Guid}/login")]
    public IActionResult Login([FromBody] LoginModel model, Guid id)
    {
        return NoContent();
    }
}