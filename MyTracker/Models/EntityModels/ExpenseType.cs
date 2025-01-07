using System;
using System.Collections.Generic;

namespace MyTracker.Models.EntityModels;

public partial class ExpenseType
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Note { get; set; }

    public virtual ICollection<GroupExpense> GroupExpenses { get; set; } = new List<GroupExpense>();
}
