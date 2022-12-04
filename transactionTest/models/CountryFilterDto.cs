using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;

namespace transactionTest.models
{
    public class CountryFilterDto : PaginationFilterBase
    {
        [CompareTo("StrName", "StrCreatedBy")]
        [StringFilterOptions(StringFilterOption.Contains)]
        public string? search { get; set; }


        public string? StrName { get; set; } = null!;

        public string? StrCreatedBy { get; set; }

        public Range<DateTime>? DteCreatedAt { get; set; }

        public string? StrUpdatedBy { get; set; }

        public DateTime? DteUpdatedAt { get; set; }

        public bool? IsActive { get; set; }
    }
}
