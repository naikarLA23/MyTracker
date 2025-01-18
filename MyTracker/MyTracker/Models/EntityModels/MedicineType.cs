using System;
using System.Collections.Generic;

namespace MyTracker.Models.EntityModels;

public partial class MedicineType
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}
