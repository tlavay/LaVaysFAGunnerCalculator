using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models
{
    public sealed class LASafety
    {
        public string Loaction { get; }
        public int BtryAlt { get; }
        public string Charge { get; }
        public string TFT { get; }
        public IEnumerable<SafetyDiagram> SafetyDiagrams { get; }
        public LASafetyRows LASafetyRows { get; }
        public IEnumerable<SafetyT> SafetyT { get; }

        public LASafety(
            string location, 
            int btryAlt, 
            string charge, 
            string tft,
            IEnumerable<SafetyDiagram> deflectionSafetyData,
            LASafetyRows laSafetyRows,
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
