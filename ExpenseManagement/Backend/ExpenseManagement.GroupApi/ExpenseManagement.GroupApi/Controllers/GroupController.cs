using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;
using ExpenseManagement.Repository.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.GroupApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;

        public GroupController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllGroup")]
        public List<Group> GetAllGroup()
        {
            GroupService groupService = new();
            return groupService.GetAllGroups();
        }

        [HttpGet("GetGroupById")]
        public Group GetGroupById(short GroupId)
        {
            GroupService groupService = new();
            return groupService.GetGroupById(GroupId);
        }

        [HttpPost("AddGroup")]
        public bool AddGroup(GroupModel GroupModel)
        {
            GroupService groupService = new();
            return groupService.AddGroup(GroupModel);
        }

        [HttpPost("EditGroup")]
        public bool EditGroup(GroupModel GroupModel)
        {
            GroupService groupService = new();
            return groupService.EditGroup(GroupModel);
        }

        [HttpDelete("DeleteGroup")]
        public bool DeleteGroup(short GroupId)
        {
            GroupService groupService = new();
            return groupService.DeleteGroup(GroupId);
        }
    }
}
