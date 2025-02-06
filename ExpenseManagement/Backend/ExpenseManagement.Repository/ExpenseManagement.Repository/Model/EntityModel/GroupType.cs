using System;
using System.Collections.Generic;

namespace ExpenseManagement.Repository.Model.EntityModel;

public partial class GroupType
{
    public short Id { get; set; }

    public string GroupType1 { get; set; } = null!;

    public string? Comments { get; set; }
}
