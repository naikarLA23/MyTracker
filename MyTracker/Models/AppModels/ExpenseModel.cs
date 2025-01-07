namespace MyTracker.Models.AppModels
{
    public class ExpenseModel
    {
        public short SplitType { get; set; }
        public required List<ExpenseDistribution> Distribution { get; set; }
    }

    public class ExpenseDistribution
    {
        public short User { get; set; }
        public int Amount { get; set; }
    }
}