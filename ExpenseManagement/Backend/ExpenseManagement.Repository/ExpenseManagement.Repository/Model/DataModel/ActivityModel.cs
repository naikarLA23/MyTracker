namespace ExpenseManagement.Repository.Model.DataModel
{
    public class ActivityModel
    {
        public short Id { get; set; }

        public short UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public short? GroupId { get; set; }

        public string Message { get; set; } = null!;
    }
}
