using System;
using System.Collections.Generic;

namespace MyTracker.Models.EntityModels;

public partial class Medicine
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public short ConsumerId { get; set; }

    public short MedicineTypeId { get; set; }

    public byte AvailableQuantity { get; set; }

    public byte? QuantityPerDay { get; set; }

    public DateTime UpdatedDate { get; set; }

    public byte RemindBefore { get; set; }

    public short CreatedBy { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? Note { get; set; }

    public virtual User Consumer { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual MedicineType MedicineType { get; set; } = null!;
}
