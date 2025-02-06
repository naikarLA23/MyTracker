using ExpenseManagement.Repository.DataAccess;
using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;

namespace ExpenseManagement.Repository.Service
{
    public class GroupService
    {
        private readonly GroupRepository _GroupRepo;

        public GroupService()
        {
            _GroupRepo = new GroupRepository();
        }

        public List<Group> GetAllGroups()
        {
            return _GroupRepo.GetAllGroups();
        }

        public Group GetGroupById(short GroupId)
        {
            return _GroupRepo.GetGroupById(GroupId);
        }

        public bool AddGroup(GroupModel groupModel)
        {
            return _GroupRepo.AddGroup(groupModel);
        }

        public bool EditGroup(GroupModel groupModel)
        {
            return _GroupRepo.EditGroup(groupModel);
        }

        public bool DeleteGroup(short groupId)
        {
            return _GroupRepo.DeleteGroup(groupId);
        }
    }
}
