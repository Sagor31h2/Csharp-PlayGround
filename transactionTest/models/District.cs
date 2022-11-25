using System;
using System.Collections.Generic;

namespace transactionTest.models;

public partial class District
{
    public long IntId { get; set; }

    public string StrName { get; set; } = null!;

    public long IntDivisionId { get; set; }

    public string? StrCreatedBy { get; set; }

    public DateTime? DteCreatedAt { get; set; }

    public string? StrUpdatedBy { get; set; }

    public DateTime? DteUpdatedAt { get; set; }

    public bool? IsActive { get; set; }
}
