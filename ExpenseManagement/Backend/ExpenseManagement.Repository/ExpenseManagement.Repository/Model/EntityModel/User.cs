using System;
using System.Collections.Generic;

namespace ExpenseManagement.Repository.Model.EntityModel;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string? Otp { get; set; }

    public string? Password { get; set; }

    public DateTime? PasswordValidUpto { get; set; }

    public string? Token { get; set; }

    public string? Status { get; set; }

    public string? Currency { get; set; }

    public string? Language { get; set; }
}
