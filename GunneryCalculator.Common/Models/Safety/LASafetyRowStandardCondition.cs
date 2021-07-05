namespace GunneryCalculator.Common.Models.Safety
{
    public sealed class LASafetyRowStandardCondition : SafetyRowBase
    {
        public int VI { get; set; }
        public decimal VT { get; set; }

        public LASafetyRowStandardCondition(
            int range,
            bool isMinTimeRange,
            int site,
            int elevation,
            int qe,
            int drift,
            decimal tof,
            int vi,
            decimal vt) : base(range, isMinTimeRange, site, elevation, qe, drift, tof)
        {
            this.VI = vi;
            this.VT = vt;
        }
    }
}
