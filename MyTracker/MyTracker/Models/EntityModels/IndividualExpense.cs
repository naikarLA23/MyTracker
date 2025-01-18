using System;
using System.Collections.Generic;

namespace MyTracker.Models.EntityModels;

public partial class IndividualExpense
{
    public int Id { get; set; }

    public short UserId { get; set; }

    public int? GroupExpenseId { get; set; }

    public short Amount { get; set; }

    public DateTime Date { get; set; }

    public string? Note { get; set; }

    public virtual GroupExpense? GroupExpense { get; set; }

    public virtual User User { get; set; } = null!;
}
