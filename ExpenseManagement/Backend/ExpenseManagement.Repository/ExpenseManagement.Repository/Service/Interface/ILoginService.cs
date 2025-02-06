using ExpenseManagement.Repository.Model.DataModel;

namespace ExpenseManagement.Repository.Service.Interface
{
    public interface ILoginService
    {
        bool IsValidUser(Login loginUser);
        bool HasAlreadyLogin(Login loginUser);

        string GetStoredRefreshToken(string userName);
        void SaveRefreshToken(TokenResponse tokenResponse);
        string GetUserRole(string userName);

    }
}
