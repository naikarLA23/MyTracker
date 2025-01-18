using Microsoft.AspNetCore.Mvc;
using MyTracker.Models.EntityModels;
using MyTracker.Service.Interface;

namespace MyTracker.Api
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class RoleController(ILogger<RoleController> logger, IConfiguration config, IRoleService roleService) : ControllerBase
    {
        [HttpGet]
        //Authorize and authenticated

        public IActionResult GetRoles()
        {
            return base.Ok(roleService.GetAllRoles()); 
        }

        [HttpGet]
        //Authorize and authenticated

        public IActionResult GetRoleById(short id)
        {
            return base.Ok(roleService.GetRoleById(id));
        }


        [HttpPost]
        //Authorize and authenticated

        public IActionResult CreateRole(Role role)
        {
            return base.Ok( roleService.CreateRole(role));
        }

        [HttpPost]
        //Authorize and authenticated

        public IActionResult UpdateRole(Role role)
        {
            return base.Ok(roleService.UpdateRole(role));
        }

        [HttpPost]
        //Authorize and authenticated

        public IActionResult DeleteRole(short id)
        {
            return base.Ok(roleService.DeleteRole(id));
        }
    }
}
