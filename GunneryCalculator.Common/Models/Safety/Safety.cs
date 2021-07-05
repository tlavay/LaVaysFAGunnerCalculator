using System.Collections.Generic;

namespace GunneryCalculator.Common.Models.Safety
{
    public sealed class Safety
    {
        public string Loaction { get; }
        public int BtryAlt { get; }
        public string Charge { get; }
        public string TFT { get; }
        public IEnumerable<SafetyDiagram> SafetyDiagrams { get; }
        public SafetyRows LASafetyRows { get; }
        public IEnumerable<SafetyT> SafetyT { get; }

        public Safety(
            string location, 
            int btryAlt, 
            string charge, 
            string tft,
            IEnumerable<SafetyDiagram> deflectionSafetyData,
            SafetyRows laSafetyRows,
            IEnumerable<SafetyT> safetyT)
        {
            this.Loaction = location;
            this.BtryAlt = btryAlt;
            this.Charge = charge;
            this.TFT = tft;
            this.SafetyDiagrams = deflectionSafetyData;
            this.LASafetyRows = laSafetyRows;
            this.SafetyT = safetyT;
        }
    }
}
