using System;
using System.Collections.Generic;

namespace ExpenseManagement.Repository.Model.EntityModel;

public partial class Alert
{
    public short Id { get; set; }

    public string AlertType { get; set; } = null!;

    public string? Comments { get; set; }
}
