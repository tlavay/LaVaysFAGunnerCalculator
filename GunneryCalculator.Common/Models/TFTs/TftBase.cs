using GunneryCalculator.Common.Models.Enums;

namespace GunneryCalculator.Common.Models.TFTs
{
    public class TftBase
    {
        public TFT TFT { get; }
        public Charge Charge { get; }
        public AngleOfFire AngleOfFire { get; }
        public int Range { get; }
        public decimal Elevation { get; }

        public TftBase(TFT tft, Charge charge, AngleOfFire angleOfFire, int range, decimal elevation)
        {
            this.TFT = tft;
            this.Charge = charge;
            this.AngleOfFire = angleOfFire;
            this.Range = range;
            this.Elevation = elevation;
        }
    }
}
