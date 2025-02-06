using System;
using System.Collections.Generic;

namespace ExpenseManagement.Repository.Model.EntityModel;

public partial class Group
{
    public short Id { get; set; }

    public string GroupName { get; set; } = null!;

    public string? Description { get; set; }

    public short? GroupTypeId { get; set; }

    public string Icon { get; set; } = null!;

    public short CreatedBy { get; set; }

    public short AdminId { get; set; }

    public string MemberIds { get; set; } = null!;

    public decimal Total { get; set; }

    public string? MemberAmount { get; set; }

    public bool IsActive { get; set; }
}
