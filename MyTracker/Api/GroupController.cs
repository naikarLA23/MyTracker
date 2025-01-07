using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTracker.Models.EntityModels;
using MyTracker.Service.Interface;

namespace MyTracker.Api
{
    [ApiController]
    [Route("[controller]/[Action]")]
    [Authorize(Roles="Admin")]
    public class GroupController(ILogger<GroupController> logger, IConfiguration config, IGroupService groupService) : ControllerBase
    {
        [HttpGet]
        //Authorize and authenticated

        public IActionResult GetGroups()
        {
            return base.Ok(groupService.GetAllGroups()); 
        }

        [HttpGet]
        //Authorize and authenticated

        public IActionResult GetGroupById(short id)
        {
            return base.Ok(groupService.GetGroupById(id));
        }


        [HttpPost]
        //Authorize and authenticated

        public IActionResult CreateGroup(Group group)
        {
            return base.Ok( groupService.CreateGroup(group));
        }

        [HttpPost]
        //Authorize and authenticated

        public IActionResult UpdateGroup(Group group)
        {
            return base.Ok(groupService.UpdateGroup(group));
        }

        [HttpPost]
        //Authorize and authenticated

        public IActionResult DeleteGroup(short id)
        {
            return base.Ok(groupService.DeleteGroup(id));
        }
    }
}
