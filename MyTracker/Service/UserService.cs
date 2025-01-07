using MyTracker.Models.AppModels;
using MyTracker.Models.EntityModels;
using MyTracker.Models.EntityModels.Context;
using MyTracker.Models.Enums;
using MyTracker.Service.Interface;

namespace MyTracker.Service
{
    public class UserService : IUserService
    {
        public ResponseModel CreateUser(User user)
        {
            try
            {
                using var dbContext = new TrackerContext();
                if (!dbContext.Users.Any(g => g.UserName == user.UserName))
                {
                    dbContext.Add(user);
                    dbContext.SaveChanges();
                    return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record created successfully", Data = user };
                }
                else
                    throw new Exception("Record already exist");
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel DeleteUser(short id)
        {
            try
            {
                using var dbContext = new TrackerContext();
                var User = dbContext.Users.First(g => g.Id == id);
                dbContext.Remove(User);
                dbContext.SaveChanges();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record deleted successfully", Data = User };
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel GetAllUsers()
        {
            try
            {
                using var dbContext = new TrackerContext();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record(s) fetched successfully", Data = dbContext.Users.Distinct().ToList() };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            } }

        public ResponseModel GetUserById(short id)
        {
            try
            {
                using var dbContext = new TrackerContext();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record fetched successfully", Data = dbContext.Users.First(g => g.Id == id) };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message};
            }
        }

        public ResponseModel UpdateUser(User user)
        {
            try
            {
                using var dbContext = new TrackerContext();
                var existingRecord = dbContext.Users.First(g => g.Id == user.Id);

                if(dbContext.Users.Any(g => g.UserName == user.UserName && g.Id != user.Id))
                {
                    throw new Exception("Record with same username already exist");
                }

                existingRecord.UserName = user.UserName;
                existingRecord.FirstName = user.FirstName;
                existingRecord.LastName = user.LastName;
                existingRecord.Age = user.Age;
                existingRecord.EmailId = user.EmailId;
                existingRecord.RoleId = user.RoleId;
                existingRecord.Gender = user.Gender;
                existingRecord.ResetPin = user.ResetPin;
                existingRecord.IsActive = user.IsActive;
                existingRecord.IsLoggedIn = user.IsLoggedIn;
                existingRecord.Password = user.Password;
                existingRecord.SessionToken = user.SessionToken;
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
