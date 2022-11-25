using System;
using System.Collections.Generic;

namespace transactionTest.models;

public partial class AllDatum
{
    public long CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public long? IntDivisionId { get; set; }

    public string? DivisionName { get; set; }

    public long? DistrictId { get; set; }

    public string? DistrictName { get; set; }
}
