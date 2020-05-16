using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models
{
    public sealed class LASafetyDataNonStandardCondition
    {
        public int QuadrantElevation { get; set; }
        public int Range { get; set; }
        public int RangeCorrection { get; set; }
        public int EntryRange { get; set; }
        public int Site { get; set; }
        public decimal Elevation { get; set; }
        public decimal TI { get; set; }
        public bool IsMinTimeRange { get; set; }
    }
}
