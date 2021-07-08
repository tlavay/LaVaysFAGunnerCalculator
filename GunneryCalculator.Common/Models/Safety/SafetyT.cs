using GunneryCalculator.Common.Models.Enums;

namespace GunneryCalculator.Common.Models.Safety
{
    public sealed class SafetyT
    {
        public AngleOfFire AngleOfFire { get; set; }
        public int MaxQE { get; }
        public Deflections Deflections { get; }
        public int MinHeQe { get; }
        public int? MinWpQe { get; }
        public decimal? MinHeTi { get; }
        public decimal? MinWpTi { get; }
        public decimal? MinVt { get; }

        public SafetyT(
            AngleOfFire angleOfFire, 
            int maxQE, 
            Deflections deflections, 
            int minHeQE, 
            int minWpQE, 
            decimal minHeTi, 
            decimal minWpTi, 
            decimal minVt)
        {
            this.AngleOfFire = angleOfFire;
            this.MaxQE = maxQE;
            this.Deflections = deflections;
            this.MinHeQe = minHeQE;
            this.MinWpQe = minWpQE;
            this.MinHeTi = minHeTi;
            this.MinWpTi = minWpTi;
            this.MinVt = minVt;
        }

        public SafetyT(
            AngleOfFire angleOfFire,
            int maxQE,
            Deflections deflections,
            int minHeQE)
        {
            this.AngleOfFire = angleOfFire;
            this.MaxQE = maxQE;
            this.Deflections = deflections;
            this.MinHeQe = minHeQE;
        }
    }
}
