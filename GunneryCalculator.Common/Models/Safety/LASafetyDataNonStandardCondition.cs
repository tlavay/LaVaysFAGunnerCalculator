namespace GunneryCalculator.Common.Models.Safety
{
    public sealed class LASafetyDataNonStandardCondition : SafetyRowBase
    {
        public int RangeCorrection { get; set; }
        public int EntryRange { get; set; }
        public LASafetyDataNonStandardCondition(
            int range,
            bool isMinTimeRange,
            int site,
            int elevation,
            int qe,
            int drift,
            decimal tof,
            int rangeCorrection,
            int entryRange) : base(range, isMinTimeRange, site, elevation, qe, drift, tof)
        {
            this.RangeCorrection = rangeCorrection;
            this.EntryRange = entryRange;
        }
    }
}
