using DevFreela.Api.Models;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.User;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly DevFreelaDbContext _context;
    
    public UserService(DevFreelaDbContext context)
    {
        _context = context;
    }
    
    public UserViewModel GetById(Guid id)
    {
        var user = _context.User.Find(x => x.Id == id)
                   ?? throw new Exception("User not found!");
        
        return new UserViewModel()
        {
            Id = user.Id,
            Name = user.FullName
        };
    }

    public void Post(CreateUserModel model)
    {
        var newUser = new User(model.UserName, model.Email, model.BirthDate);
        _context.User.Add(newUser);
    }

    public void PostComments(CreateCommentModel model, Guid id)
    {
        var comment = _context.ProjectComments.Find(x => x.Id == id)
                      ?? throw new Exception("Post not found.");
        
        var newComment = new ProjectComment(model.Content, comment.IdProject, id);
        
        _context.ProjectComments.Add(newComment);
    }

    public void Start(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Finish(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Login(LoginModel model, Guid id)
    {
        throw new NotImplementedException();
    }
}