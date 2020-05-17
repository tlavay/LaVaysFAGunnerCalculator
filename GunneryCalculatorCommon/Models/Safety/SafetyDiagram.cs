using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models.Safety
{
    public sealed class SafetyDiagram
    {
        public Deflections Deflections { get; }
        public int AOF { get; }
        public int MinRange { get; }
        public int MaxAltitude { get; }
        public int MinTimeRange { get; }
        public int MaxRange { get; }
        public int MinAltitude { get; }
        public SafetyDiagram(
            Deflections deflections,
            int aof,
            int minRange,
            int maxAltitude,
            int minTimeRange,
            int maxRange,
            int minAltitude)
        {
            this.Deflections = deflections;
            this.AOF = aof;
            this.MinRange = minRange;
            this.MaxAltitude = maxAltitude;
            this.MinTimeRange = minTimeRange;
            this.MaxRange = maxRange;
            this.MinAltitude = minAltitude;
        }
    }
}
