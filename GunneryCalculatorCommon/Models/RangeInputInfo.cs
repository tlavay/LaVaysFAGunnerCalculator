using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models
{
    public sealed class RangeInputInfo
    {
        public int Range { get; set; }
        public int Altitude { get; set; }
        public bool IsMinTimeRange { get; set; }
    }
}
