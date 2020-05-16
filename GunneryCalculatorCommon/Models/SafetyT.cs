using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models
{
    public sealed class SafetyT
    {
        public int MaxQE { get; }
        public Deflections Deflections { get; }
        public int MinHeQe { get; }
        public int MinWpQe { get; }
        public decimal MinHeTi { get; }
        public decimal MinWpTi { get; }
        public decimal MinVt { get; }

        public SafetyT(int maxQE, Deflections deflections, int minHeQE, int minWpQE, decimal minHeTi, decimal minWpTi, decimal minVt)
        {
            this.MaxQE = maxQE;
            this.Deflections = deflections;
            this.MinHeQe = minHeQE;
            this.MinWpQe = minWpQE;
            this.MinHeTi = minHeTi;
            this.MinWpTi = minWpTi;
            this.MinVt = minVt;
        }
    }
}
