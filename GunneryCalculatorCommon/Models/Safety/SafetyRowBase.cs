using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models.Safety
{
    public class SafetyRowBase
    {
        public int Range { get; }
        public bool IsMinTimeRange { get; }
        public int Site { get; }
        public int Elevation { get; }
        public int QuadrantElevation { get; }
        public int Drift { get; }
        public decimal TimeOfFlight { get; }

        public SafetyRowBase(int range, bool isMinTimeRange, int site, int elevation, int qe, int drift, decimal tof)
        {
            this.Range = range;
            this.IsMinTimeRange = isMinTimeRange;
            this.Site = site;
            this.Elevation = elevation;
            this.QuadrantElevation = qe;
            this.Drift = drift;
            this.TimeOfFlight = tof;
        }
    }
}
