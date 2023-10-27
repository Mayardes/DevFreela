using DevFreela.Api.Models;
using DevFreela.Application.ViewModels.User;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    UserViewModel GetById(Guid id);
    void Post(CreateUserModel model);
    void PostComments(CreateCommentModel model, Guid id);
    void Start(Guid id);
    void Finish(Guid id);
    void Login(LoginModel model, Guid id);
}