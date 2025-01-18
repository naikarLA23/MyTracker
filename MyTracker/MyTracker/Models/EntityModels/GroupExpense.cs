namespace MyTracker.Models.EntityModels;

public partial class GroupExpense
{
    public int Id { get; set; }

    public short GroupId { get; set; }

    public short ExpenseId { get; set; }

    public int Total { get; set; }

    public DateTime Date { get; set; }

    public short CreatedBy { get; set; }

    public string? ExpenseDetails { get; set; }

    public string? Note { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ExpenseType Expense { get; set; } = null!;

    public virtual ICollection<IndividualExpense> IndividualExpenses { get; set; } = new List<IndividualExpense>();
}
