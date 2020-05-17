using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models.Safety
{
    public sealed class HASafetyRowDataStandardCondition : SafetyRowBase
    {
        public HASafetyRowDataStandardCondition(
            int range,
            bool isMinTimeRange, 
            int site, 
            int elevation, 
            int qe, 
            int drift, 
            decimal tof) : base(range, isMinTimeRange, site, elevation, qe, drift, tof)
        {
        }
    }
}
