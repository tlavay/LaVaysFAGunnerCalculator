using GunneryCalculator.Common.Models.Enums;

namespace GunneryCalculator.Common.Models.Safety
{
    public sealed class SafetyDiagramSection
    {
        public int Range { get; set; }
        public int Altitude { get; set; }
        public bool IsMinTimeRange { get; set; }
        public int LeftLimit { get; set; }
        public int RightLimit { get; set; }
        public AngleOfFire AngleOfFire { get; set; }
    }
}
