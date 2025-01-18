using Microsoft.AspNetCore.Mvc;
using MyTracker.Models.EntityModels;
using MyTracker.Service.Interface;

namespace MyTracker.Api
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class GroupExpenseController(ILogger<GroupExpenseController> logger, IConfiguration config, IGroupExpenseService groupExpenseService) : ControllerBase
    {
        [HttpGet]
        //Authorize and authenticated

        public IActionResult GetGroupExpenses()
        {
            return base.Ok(groupExpenseService.GetAllGroupExpenses()); 
        }

        [HttpGet]
        //Authorize and authenticated

        public IActionResult GetGroupExpenseById(short id)
        {
            return base.Ok(groupExpenseService.GetGroupExpenseById(id)); 
        }


        [HttpPost]
        //Authorize and authenticated

        public IActionResult CreateGroupExpense(GroupExpense groupExpense)
        {
            return base.Ok( groupExpenseService.CreateGroupExpense(groupExpense));
        }

        [HttpPost]
        //Authorize and authenticated

        public IActionResult UpdateGroupExpense(GroupExpense groupExpense)
        {
            return base.Ok(groupExpenseService.UpdateGroupExpense(groupExpense));
        }

        [HttpPost]
        //Authorize and authenticated

        public IActionResult DeleteGroupExpense(short id)
        {
            return base.Ok(groupExpenseService.DeleteGroupExpense(id));
        }
    }
}
