using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models
{
    public sealed class LASafetyRows
    {
        public IEnumerable<LASafetyRowStandardCondition> LASafetyRowStandardConditions { get; }
        public IEnumerable<LASafetyDataNonStandardCondition> LASafetyDataNonStandardConditions;
        public LASafetyRows(
            IEnumerable<LASafetyRowStandardCondition> laSafetyRowStandardConditions, 
            IEnumerable<LASafetyDataNonStandardCondition> laSafetyDataNonStandardConditions)
        {
            this.LASafetyRowStandardConditions = laSafetyRowStandardConditions;
            this.LASafetyDataNonStandardConditions = laSafetyDataNonStandardConditions;
        }
    }
}
