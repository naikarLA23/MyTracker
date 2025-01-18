using MyTracker.Models.AppModels;
using MyTracker.Models.EntityModels;

namespace MyTracker.Service.Interface
{
    public interface IGroupService
    {
        ResponseModel GetAllGroups();

        ResponseModel GetGroupById(short id);

        ResponseModel CreateGroup(Group group);

        ResponseModel UpdateGroup(Group group);

        ResponseModel DeleteGroup(short id);
    }
}
