using Microsoft.EntityFrameworkCore;
using MyTracker.Models.AppModels;
using MyTracker.Models.EntityModels;
using MyTracker.Models.EntityModels.Context;
using MyTracker.Models.Enums;
using MyTracker.Service.Interface;
using System.Linq;

namespace MyTracker.Service
{
    public class RoleService : IRoleService
    {
        public ResponseModel CreateRole(Role role)
        {
            try
            {
                using var dbContext = new TrackerContext();
                if (!dbContext.Roles.Any(r => r.RoleType == role.RoleType))
                {
                    dbContext.Add(role);
                    dbContext.SaveChanges();
                    return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record created successfully", Data = role };
                }
                else
                    throw new Exception("Record already exist");
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel DeleteRole(short id)
        {
            try
            {
                using var dbContext = new TrackerContext();
                var role = dbContext.Roles.First(r => r.Id == id);
                dbContext.Remove(role);
                dbContext.SaveChanges();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record deleted successfully", Data = role };
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel GetAllRoles()
        {
            try
            {
                using var dbContext = new TrackerContext();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record(s) fetched successfully", Data = dbContext.Roles.Distinct().ToList() };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            } }

        public ResponseModel GetRoleById(short id)
        {
            try
            {
                using var dbContext = new TrackerContext();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record fetched successfully", Data = dbContext.Roles.First(r => r.Id == id) };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message};
            }
        }

        public ResponseModel UpdateRole(Role role)
        {
            try
            {
                using var dbContext = new TrackerContext();
                var existingRecord = dbContext.Roles.First(r => r.Id == role.Id);
                existingRecord.RoleType = role.RoleType;
                existingRecord.Note = role.Note;
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
