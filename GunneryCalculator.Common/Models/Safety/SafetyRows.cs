﻿using System.Collections.Generic;

namespace GunneryCalculator.Common.Models.Safety
{
    public sealed class SafetyRows
    {
        public IEnumerable<LASafetyRowStandardCondition> LASafetyRowStandardConditions { get; }
        public IEnumerable<LASafetyDataNonStandardCondition> LASafetyDataNonStandardConditions { get; }
        public IEnumerable<HASafetyRowDataStandardCondition> HASafetyRowDataStandardCondition { get; }
        public SafetyRows(
            IEnumerable<LASafetyRowStandardCondition> laSafetyRowStandardConditions, 
            IEnumerable<LASafetyDataNonStandardCondition> laSafetyDataNonStandardConditions,
            IEnumerable<HASafetyRowDataStandardCondition> haSafetyRowDataStandardCondition)
        {
            this.LASafetyRowStandardConditions = laSafetyRowStandardConditions;
            this.LASafetyDataNonStandardConditions = laSafetyDataNonStandardConditions;
            this.HASafetyRowDataStandardCondition = haSafetyRowDataStandardCondition;
        }
    }
}
