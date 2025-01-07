using System;
using System.Collections.Generic;

namespace MyTracker.Models.EntityModels;

public partial class Gender
{
    public byte Id { get; set; }

    public string GenderType { get; set; } = null!;
}
