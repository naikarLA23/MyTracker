using MyTracker.Models.AppModels;
using MyTracker.Models.EntityModels;

namespace MyTracker.Service.Interface
{
    public interface IRoleService
    {
        ResponseModel GetAllRoles();

        ResponseModel GetRoleById(short id);

        ResponseModel CreateRole(Role role);

        ResponseModel UpdateRole(Role role);

        ResponseModel DeleteRole(short id);

    }
}
