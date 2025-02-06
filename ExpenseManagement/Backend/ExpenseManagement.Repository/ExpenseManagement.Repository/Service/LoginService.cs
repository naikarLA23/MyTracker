using ExpenseManagement.Repository.DataAccess;
using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Service.Interface;

namespace ExpenseManagement.Repository.Service
{
    public class LoginService : ILoginService
    {
        private readonly UserRepository _UserRepo;

        public LoginService()
        {
            _UserRepo = new UserRepository();
        }
        public bool IsValidUser(Login loginUser)
        {
            return _UserRepo.IsValidUser(loginUser);
        }

        public bool HasAlreadyLogin(Login loginUser)
        {
            return _UserRepo.HasAlreadyLogin(loginUser);
        }

        public string GetStoredRefreshToken(string userName)
        {
            return _UserRepo.GetStoredRefreshToken(userName);
        }

        public void SaveRefreshToken(TokenResponse tokenResponse)
        {
            _UserRepo.SaveRefreshToken(tokenResponse);
        }
        public string GetUserRole(string userName)
        {
            return _UserRepo.GetUserRole(userName);
        }
    }
}
