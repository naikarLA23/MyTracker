using System;
using System.Collections.Generic;

namespace ExpenseManagement.Repository.Model.EntityModel;

public partial class Question
{
    public short Id { get; set; }

    public string Questions { get; set; } = null!;
}
