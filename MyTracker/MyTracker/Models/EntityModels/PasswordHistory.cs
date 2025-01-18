using System;
using System.Collections.Generic;

namespace MyTracker.Models.EntityModels;

public partial class PasswordHistory
{
    public short UserId { get; set; }

    public string Password { get; set; } = null!;

    public DateTime Date { get; set; }
}
