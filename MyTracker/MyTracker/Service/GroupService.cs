using MyTracker.Models.AppModels;
using MyTracker.Models.EntityModels;
using MyTracker.Models.EntityModels.Context;
using MyTracker.Models.Enums;
using MyTracker.Service.Interface;

namespace MyTracker.Service
{
    public class GroupService : IGroupService
    {
        public ResponseModel CreateGroup(Group group)
        {
            try
            {
                using var dbContext = new TrackerContext();
                if (!dbContext.Groups.Any(g => g.Name == group.Name))
                {
                    dbContext.Add(group);
                    dbContext.SaveChanges();
                    return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record created successfully", Data = group };
                }
                else
                    throw new Exception("Record already exist");
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel DeleteGroup(short id)
        {
            try
            {
                using var dbContext = new TrackerContext();
                var group = dbContext.Groups.First(g => g.Id == id);
                dbContext.Remove(group);
                dbContext.SaveChanges();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record deleted successfully", Data = group };
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel GetAllGroups()
        {
            try
            {
                using var dbContext = new TrackerContext();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record(s) fetched successfully", Data = dbContext.Groups.Distinct().ToList() };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            } }

        public ResponseModel GetGroupById(short id)
        {
            try
            {
                using var dbContext = new TrackerContext();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record fetched successfully", Data = dbContext.Groups.First(g => g.Id == id) };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message};
            }
        }

        public ResponseModel UpdateGroup(Group group)
        {
            try
            {
                using var dbContext = new TrackerContext();
                var existingRecord = dbContext.Groups.First(g => g.Id == group.Id);

                if(dbContext.Groups.Any(g => g.Name == group.Name && g.Id != group.Id))
                {
                    throw new Exception("Record with same name already exist");
                }

                existingRecord.Name = group.Name;
                existingRecord.MemberIds = group.MemberIds;
                existingRecord.AdminIds = group.AdminIds;
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
