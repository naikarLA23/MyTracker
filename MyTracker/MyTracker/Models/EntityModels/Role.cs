using System;
using System.Collections.Generic;

namespace MyTracker.Models.EntityModels;

public partial class Role
{
    public short Id { get; set; }

    public string RoleType { get; set; } = null!;

    public string? Note { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
