using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTracker.Models.EntityModels;
using MyTracker.Service.Interface;

namespace MyTracker.Api
{
    [ApiController]
    [Route("[controller]/[Action]")]
    [Authorize(Roles = "Admin")]

    public class UserController(ILogger<UserController> logger, IConfiguration config, IUserService userService) : ControllerBase
    {

        [HttpGet]
        //Authorize and authenticated

        public IActionResult GetUsers()
        {
            return base.Ok(userService.GetAllUsers());
        }

        [HttpGet]
        //Authorize and authenticated

        public IActionResult GetUserById(short id)
        {
            return base.Ok(userService.GetUserById(id));
        }


        [HttpPost]
        //Authorize and authenticated

        public IActionResult CreateUser(User User)
        {
            return base.Ok(userService.CreateUser(User));
        }

        [HttpPost]
        //Authorize and authenticated

        public IActionResult UpdateUser(User User)
        {
            return base.Ok(userService.UpdateUser(User));
        }

        [HttpPost]
        //Authorize and authenticated

        public IActionResult DeleteUser(short id)
        {
            return base.Ok(userService.DeleteUser(id));
        }

    }
}
