using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models
{
    public sealed class SafetyDiagramSection
    {
        public int Range { get; set; }
        public int Altitude { get; set; }
        public bool IsMinTimeRange { get; set; }
        public int LeftLimit { get; set; }
        public int RightLimit { get; set; }
    }
}
