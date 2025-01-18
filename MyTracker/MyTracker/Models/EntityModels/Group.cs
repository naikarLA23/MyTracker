using System;
using System.Collections.Generic;

namespace MyTracker.Models.EntityModels;

public partial class Group
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public string MemberIds { get; set; } = null!;

    public string AdminIds { get; set; } = null!;

    public short? CreatedBy { get; set; }

    public string? Date { get; set; }

    public string? Note { get; set; }
}
