namespace ExpenseManagement.Repository.Model.DataModel
{
    public class UserModel
    {
        public int Id { get; set; } 
        public string UserName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string MobileNo { get; set; } = null!;

        public string? Password { get; set; }

        public string? Currency { get; set; }

        public string? Language { get; set; }
        public string? Status { get; internal set; }
        public string? Otp { get; internal set; }
    }
}
