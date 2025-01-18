using MyTracker.Models.AppModels;
using MyTracker.Models.EntityModels;

namespace MyTracker.Service.Interface
{
    public interface IGroupExpenseService
    {

        ResponseModel GetAllGroupExpenses();

        ResponseModel GetGroupExpenseById(short id);

        ResponseModel CreateGroupExpense(GroupExpense groupExpense);

        ResponseModel UpdateGroupExpense(GroupExpense groupExpense);

        ResponseModel DeleteGroupExpense(short id);

    }
}
