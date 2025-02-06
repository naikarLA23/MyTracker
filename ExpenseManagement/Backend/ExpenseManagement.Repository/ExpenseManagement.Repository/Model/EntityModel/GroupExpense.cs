namespace ExpenseManagement.Repository.Model.EntityModel;

public partial class GroupExpense
{
    public short Id { get; set; }

    public short GroupId { get; set; }

    public short CreatedBy { get; set; }

    public string? Description { get; set; }

    public string? IndividualSplit { get; set; }
}
