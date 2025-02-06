using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;
using ExpenseManagement.Repository.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllUser")]
        public List<User> GetAllUser()
        {
            UserService userService = new();
            return userService.GetAllUsers();
            //return Task.CompletedTask;
        }

        [HttpGet("GetUserById")]
        public User GetUserById(short userId)
        {
            UserService userService = new();
            return userService.GetUserById(userId);
        }


        [HttpPost("AddUser")]
        public bool AddUser(UserModel userModel)
        {
            UserService userService = new();
            return userService.AddUser(userModel);
        }

        [HttpPost("EditUser")]
        public bool EditUser(UserModel userModel)
        {
            UserService userService = new();
            return userService.EditUser(userModel);
        }

        [HttpDelete("DeleteUser")]
        public bool DeleteUser(short userId)
        {
            UserService userService = new();
           return userService.DeleteUser(userId);
        }

        [HttpPost("ChangePassword")]
        public bool ChangePassword(UserModel userModel)
        {
            UserService userService = new();
            return userService.ChangePassword(userModel);
        }

        [HttpPost("ChangeOtp")]
        public bool ChangeOtp(UserModel userModel)
        {
            UserService userService = new();
            return userService.ChangeOtp(userModel);
        }
    }
}
