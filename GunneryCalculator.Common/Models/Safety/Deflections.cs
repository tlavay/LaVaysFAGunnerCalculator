using GunneryCalculator.Common.Models.Enums;

namespace GunneryCalculator.Common.Models.Safety
{
    public sealed class Deflections
    {
        public AngleOfFire AngleOfFire { get; set; }
        public int Left { get; }
        public int Right { get; }
        public Deflections(AngleOfFire angleOfFire, int left, int right)
        {
            this.AngleOfFire = angleOfFire;
            this.Left = left;
            this.Right = right;
        }
    }
}
