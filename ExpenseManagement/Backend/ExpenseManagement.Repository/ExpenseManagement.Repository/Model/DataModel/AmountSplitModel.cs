namespace ExpenseManagement.Repository.Model.DataModel
{
    public class AmountSplitModel
    {
        public string SplitType { get; set; }
        public List<Split> Splits { get; set; }
        public decimal TotalSpending { get; set; }
    }

    public class Split
    {
        public short UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public decimal AmountPaid { get; set; }
        public decimal DueAmount { get; set; }
    }
}