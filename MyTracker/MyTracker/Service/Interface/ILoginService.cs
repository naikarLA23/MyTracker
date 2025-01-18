using MyTracker.Models.AppModels;
using MyTracker.Models.EntityModels;

namespace MyTracker.Service.Interface
{
    public interface IUserService
    {
        ResponseModel GetAllUsers();

        ResponseModel GetUserById(short id);

        ResponseModel CreateUser(User user);

        ResponseModel UpdateUser(User user);

        ResponseModel DeleteUser(short id);

    }
}
