using ExpenseManagement.Repository.DataAccess;
using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;

namespace ExpenseManagement.Repository.Service
{
    public class UserService
    {
        private readonly UserRepository _UserRepo;

        public UserService()
        {
            _UserRepo = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            return _UserRepo.GetAllUsers();
        }

        public User GetUserById(short userId)
        {
            return _UserRepo.GetUserById(userId);
        }

        public bool AddUser(UserModel userModel)
        {
           return _UserRepo.AddUser(userModel);
        }

        public bool EditUser(UserModel userModel)
        {
            return _UserRepo.EditUser(userModel);
        }

        public bool DeleteUser(short userId)
        {
            return _UserRepo.DeleteUser(userId);
        }

        public bool ChangePassword(UserModel userModel)
        {
            return _UserRepo.ChangePassword(userModel);
        }

        public bool ChangeOtp(UserModel userModel)
        {
            return _UserRepo.ChangeOtp(userModel);
        }

    }
}
