namespace ExpenseManagement.Repository.Model.DataModel;

public partial class GroupExpenseModel
{
    public short Id { get; set; }

    public short GroupId { get; set; }

    public short CreatedBy { get; set; }

    public string? Description { get; set; }
    public string? IndividualSplitStr { get; set; }

    public AmountSplitModel IndividualSplitJson { get; set; }
}
