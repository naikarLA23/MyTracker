using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;
using ExpenseManagement.Repository.Model.EntityModel.Context;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace ExpenseManagement.Repository.DataAccess
{
    internal class UserRepository
    {
        internal List<User> GetAllUsers()
        {
            try
            {
                List<User> users = new();
                using var context = new ExpenseManagementContext();
                users = context.Users.ToList<User>();

                return users;
            }
            catch (Exception)
            {

                return null;
            }
        }
        internal User GetUserById(short userId)
        {
            try
            {
                User user = new();
                using var context = new ExpenseManagementContext();
                user = context.Users.First(u => u.Id == userId);

                return user;
            }
            catch (Exception)
            {

                return null;
            }
        }
       
        internal bool AddUser(UserModel userModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingUser = context.Users.FirstOrDefault(u => u.UserName == userModel.UserName);
                if (existingUser == null && IsValidPassword(userModel, existingUser))
                {

                    User user = new()
                    {
                        UserName = userModel.UserName,
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        Gender = userModel.Gender,
                        Email = userModel.Email,
                        MobileNo = userModel.MobileNo,
                        Password = userModel.Password,
                        Language = userModel.Language,
                        Currency = userModel.Currency,
                        PasswordValidUpto = DateTime.Now.AddDays(30),
                        Status = "Active"
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false; //User exist
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        internal bool EditUser(UserModel userModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingUser = context.Users.First(u=>u.Id== userModel.Id);
                if (existingUser != null)
                {
                    existingUser.UserName = userModel.UserName;
                    existingUser.FirstName = userModel.FirstName;
                    existingUser.LastName = userModel.LastName;
                    existingUser.Gender = userModel.Gender;
                    existingUser.Email = userModel.Email;
                    existingUser.MobileNo = userModel.MobileNo;

                    existingUser.Language = userModel.Language;
                    existingUser.Currency = userModel.Currency;
                    existingUser.Status = userModel.Status;

                    if (IsValidPassword(userModel, existingUser))
                        existingUser.Password = userModel.Password;

                    context.Users.Update(existingUser);
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

        internal bool DeleteUser(short id)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingUser = context.Users.First(u => u.Id == id);
                if (existingUser != null)
                {
                    existingUser.Status = "Inactive";
                    context.Users.Update(existingUser);
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

        internal bool ChangePassword(UserModel userModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingUser = context.Users.FirstOrDefault(u => u.UserName == userModel.UserName);
                if (existingUser != null && IsValidPassword(userModel, existingUser))
                {
                    existingUser.Password = userModel.Password;

                    context.Users.Update(existingUser);
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

        internal bool ChangeOtp(UserModel userModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingUser = context.Users.FirstOrDefault(u => u.UserName == userModel.UserName);
                if (existingUser != null && existingUser.Otp != userModel.Otp && userModel.Otp.Length == 6)
                {
                    existingUser.Otp = userModel.Otp;

                    context.Users.Update(existingUser);
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

        private bool IsValidPassword(UserModel userModel, User existingUser)
        {
            bool isValid;
            if (existingUser != null)
            {
                if (userModel.Password != existingUser.Password)
                    throw new Exception("Old password and New password are same");

                isValid = true;
            }
            if (userModel.Password.Length < 8)
                throw new Exception("Password should be of minimum 8 character length");

            //if (userModel.Password.Count(c=> char.IsUpper(c)) < 1 || userModel.Password.Count(c => char.IsDigit(c)) < 1 
            //    || userModel.Password.Count(c => !char.IsLetterOrDigit(c)) < 1)

            if (Regex.IsMatch(userModel.Password, "^[a-zA-Z0-9\x20]+$"))
                throw new Exception(" Password should have minimum 1 upper case char, 1 special character, 1 digit");

            isValid = true;

            return isValid;
        }

        internal bool IsValidUser(Login loginUser)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                User existingUser;

                if(!string.IsNullOrEmpty(loginUser.UserName))
                {
                    existingUser = context.Users.First(u => u.UserName == loginUser.UserName);
                    return existingUser != null && existingUser.Status == "Active" &&
                       (existingUser.Password == loginUser.Password);
                }
                else if (!string.IsNullOrEmpty(loginUser.EmailId))
                {
                    existingUser = context.Users.First(u => u.Email == loginUser.EmailId);
                    return existingUser != null && existingUser.Status == "Active" &&
                       (existingUser.Password == loginUser.Password);
                }
                else if (!string.IsNullOrEmpty(loginUser.MobileNo))
                {
                    existingUser = context.Users.First(u => u.MobileNo == loginUser.MobileNo);
                    return existingUser != null && existingUser.Status == "Active" &&
                       (existingUser.Otp == loginUser.Otp);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool HasAlreadyLogin(Login loginUser)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingUser = context.Users.First(u => u.UserName == loginUser.UserName || 
                u.Email == loginUser.EmailId ||
                u.MobileNo == loginUser.MobileNo);
                return existingUser != null && existingUser.Status != "Active"; // Add new column already logged in
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal string GetStoredRefreshToken(string userName)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingUser = context.Users.First(u => u.UserName == userName);
                return existingUser?.Token ?? string.Empty; // Add new column Refersh Token
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void SaveRefreshToken(TokenResponse tokenResponse)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingUser = context.Users.First(u => u.UserName == tokenResponse.UserName);
                if(existingUser!=null)
                {
                    existingUser.Token = tokenResponse.Token; // Add new column Refersh Token
                    context.Users.Update(existingUser);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal string GetUserRole(string userName)
        {
            return "Admin";
            //try
            //{
            //    using var context = new ExpenseManagementContext();
            //    var existingUser = context.Users.First(u => u.UserName == tokenResponse.UserName);
            //    if (existingUser != null)
            //    {
            //        existingUser.Token = tokenResponse.Token; // Add new column Refersh Token
            //        context.Users.Update(existingUser);
            //        context.SaveChanges();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}