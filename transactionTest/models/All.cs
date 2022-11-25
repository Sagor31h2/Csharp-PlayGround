using System;
using System.Collections.Generic;

namespace transactionTest.models;

public partial class All
{
    public long CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public long DivisionId { get; set; }

    public string? DivisionName { get; set; }

    public long DistrictId { get; set; }

    public string? DistrictName { get; set; }
}
