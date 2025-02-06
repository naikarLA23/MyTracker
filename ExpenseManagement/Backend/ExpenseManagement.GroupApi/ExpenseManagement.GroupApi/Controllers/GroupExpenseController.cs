using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;
using ExpenseManagement.Repository.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.GroupApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupExpenseController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;

        public GroupExpenseController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllGroupExpenses")]
        public List<GroupExpense> GetAllGroupExpenses()
        {
            GroupExpenseService groupExpenseService = new();
            return groupExpenseService.GetAllGroupExpenses();
        }

        [HttpGet("GetAllGroupExpensesForGroupId")]
        public List<GroupExpense> GetAllGroupExpensesForGroupId(short groupId)
        {
            GroupExpenseService groupExpenseService = new();
            return groupExpenseService.GetAllGroupExpensesForGroupId(groupId);
        }

        [HttpGet("GetGroupExpensesById")]
        public GroupExpense GetGroupExpensesById(short groupExpenseId)
        {
            GroupExpenseService groupExpenseService = new();
            return groupExpenseService.GetGroupExpensesById(groupExpenseId);
        }

        [HttpPost("AddGroupExpense")]
        public bool AddGroupExpense(GroupExpenseModel groupExpenseModel)
        {
            GroupExpenseService groupExpenseService = new();
            return groupExpenseService.AddGroupExpense(groupExpenseModel);
        }

        [HttpPost("EditGroupExpense")]
        public bool EditGroupExpense(GroupExpenseModel groupExpenseModel)
        {
            GroupExpenseService groupExpenseService = new();
            return groupExpenseService.EditGroupExpense(groupExpenseModel);
        }

        [HttpDelete("DeleteGroupExpense")]
        public bool DeleteGroupExpense(short groupExpenseId)
        {
            GroupExpenseService groupExpenseService = new();
            return groupExpenseService.DeleteGroupExpense(groupExpenseId);
        }
    }
}
