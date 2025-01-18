using MyTracker.Models.AppModels;
using MyTracker.Models.EntityModels;
using MyTracker.Models.EntityModels.Context;
using MyTracker.Models.Enums;
using MyTracker.Service.Interface;

namespace MyTracker.Service
{
    public class GroupExpenseService : IGroupExpenseService
    {
        public ResponseModel CreateGroupExpense(GroupExpense groupExpense)
        {
            try
            {
                using var dbContext = new TrackerContext();
                dbContext.Add(groupExpense);
                dbContext.SaveChanges();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record created successfully", Data = groupExpense };
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel DeleteGroupExpense(short id)
        {
            try
            {
                using var dbContext = new TrackerContext();
                var groupExpense = dbContext.GroupExpenses.First(g => g.Id == id);
                dbContext.Remove(groupExpense);
                dbContext.SaveChanges();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record deleted successfully", Data = groupExpense };
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel GetAllGroupExpenses()
        {
            try
            {
                using var dbContext = new TrackerContext();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record(s) fetched successfully", Data = dbContext.GroupExpenses.Distinct().ToList() };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            } }

        public ResponseModel GetGroupExpenseById(short id)
        {
            try
            {
                using var dbContext = new TrackerContext();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record fetched successfully", Data = dbContext.GroupExpenses.First(g => g.Id == id) };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message};
            }
        }

        public ResponseModel UpdateGroupExpense(GroupExpense group)
        {
            try
            {
                using var dbContext = new TrackerContext();
                var existingRecord = dbContext.GroupExpenses.First(g => g.Id == group.Id);
                existingRecord.GroupId = group.GroupId;
                existingRecord.ExpenseId = group.ExpenseId;
                existingRecord.Total = group.Total;
                existingRecord.ExpenseDetails = group.ExpenseDetails;
                existingRecord.Note = group.Note;
                dbContext.Update(existingRecord);
                dbContext.SaveChanges();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record updated successfully", Data = existingRecord };
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }
    }
}
