using DevFreela.Application.InputModels.User;
using DevFreela.Application.ViewModels.User;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    UserViewModel GetById(Guid id);
    void Post(CreateUserInputModel model);
    void PostComments(CreateCommentInputModel model, Guid id);
    void Login(LoginInputModel model, Guid id);
}