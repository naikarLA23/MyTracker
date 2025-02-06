using System;
using System.Collections.Generic;

namespace ExpenseManagement.Repository.Model.EntityModel;

public partial class Activity
{
    public short Id { get; set; }

    public short UserId { get; set; }

    public DateTime CreatedOn { get; set; }

    public short? GroupId { get; set; }

    public string Message { get; set; } = null!;
}
