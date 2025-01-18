using System;
using System.Collections.Generic;

namespace MyTracker.Models.EntityModels;

public partial class User
{
    public short Id { get; set; }

    public string UserName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public byte? Age { get; set; }

    public string? Gender { get; set; }

    public short RoleId { get; set; }

    public string EmailId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsLoggedIn { get; set; }

    public string? SessionToken { get; set; }

    public string? Notes { get; set; }

    public short? ResetPin { get; set; }

    public virtual ICollection<GroupExpense> GroupExpenses { get; set; } = new List<GroupExpense>();

    public virtual ICollection<IndividualExpense> IndividualExpenses { get; set; } = new List<IndividualExpense>();

    public virtual ICollection<Medicine> MedicineConsumers { get; set; } = new List<Medicine>();

    public virtual ICollection<Medicine> MedicineCreatedByNavigations { get; set; } = new List<Medicine>();

    public virtual Role Role { get; set; } = null!;
}
