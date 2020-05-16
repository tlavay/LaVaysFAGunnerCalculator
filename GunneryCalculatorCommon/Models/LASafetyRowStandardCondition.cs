using GunneryCalculatorCommon.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models
{
    public sealed class LASafetyRowStandardCondition
    {
        public int Range { get; set; }
        public bool IsMinTimeRange { get; set; }
        public int VI { get; set; }
        public decimal Site { get; set; }
        public decimal Elevation { get; set; }
        public int QuadrantElevation { get; set; }
        public decimal TimeOfFlight { get; set; }
        public decimal VT { get; set; }
        public int Drift { get; set; }
    }
}
