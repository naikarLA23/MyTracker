namespace ExpenseManagement.Authentication.Helper.Constants
{
    public class ErrorMessages
    {
        public const string WRONG_CREDENTIAL = "Failed to login. Wrong Username / Password or user is inactive";
        public const string ALREADY_LOGGED = "Failed to login. User has already logged in some other app";
        public const string TOKEN_MISSMATCH = "Forced logout. Session token invalidated";
    }
}
