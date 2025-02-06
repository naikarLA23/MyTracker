using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;
using ExpenseManagement.Repository.Model.EntityModel.Context;
using Newtonsoft.Json;

namespace ExpenseManagement.Repository.DataAccess
{
    internal class GroupExpenseRepository
    {
        internal List<GroupExpense> GetAllGroupExpenses()
        {
            try
            {
                List<GroupExpense> groupExpense = new();
                using var context = new ExpenseManagementContext();
                groupExpense = context.GroupExpenses.ToList<GroupExpense>();

                return groupExpense;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal List<GroupExpense> GetAllGroupExpensesForGroupId(short groupId)
        {
            try
            {
                List<GroupExpense> groupExpense = new();
                using var context = new ExpenseManagementContext();
                groupExpense = context.GroupExpenses.Where(ge => ge.GroupId == groupId).ToList<GroupExpense>();

                return groupExpense;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal GroupExpense GetGroupExpensesById(short groupExpenseId)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                return context.GroupExpenses.FirstOrDefault(ge => ge.Id == groupExpenseId) ;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal bool AddGroupExpense(GroupExpenseModel groupExpenseModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                GroupExpense groupExpense = new()
                {
                    GroupId = groupExpenseModel.GroupId,
                    CreatedBy = groupExpenseModel.CreatedBy,
                    IndividualSplit = JsonConvert.SerializeObject(groupExpenseModel.IndividualSplitJson),
                    Description = groupExpenseModel.Description
                };

                context.GroupExpenses.Add(groupExpense);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        internal bool EditGroupExpense(GroupExpenseModel groupExpenseModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingGroupExpense = context.GroupExpenses.First(u => u.Id == groupExpenseModel.Id);
                if (existingGroupExpense != null)
                {
                    existingGroupExpense.IndividualSplit = JsonConvert.SerializeObject(groupExpenseModel.IndividualSplitJson);
                    existingGroupExpense.Description = groupExpenseModel.Description;

                    context.GroupExpenses.Update(existingGroupExpense);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        internal bool DeleteGroupExpense(short id)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingGroupExpense = context.GroupExpenses.First(u => u.Id == id);
                if (existingGroupExpense != null)
                {
                    context.GroupExpenses.Remove(existingGroupExpense);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
