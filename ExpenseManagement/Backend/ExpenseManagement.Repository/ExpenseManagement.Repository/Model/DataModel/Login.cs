namespace ExpenseManagement.Repository.Model.DataModel
{
    public class Login
    {
        public string UserName { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Otp { get; set; } = string.Empty;
        public string? MobileNo { get; set; } = string.Empty;
    }
}
