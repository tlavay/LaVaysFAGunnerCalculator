using GunneryCalculatorCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GunneryCalculatorCommon.Services.Builders
{
    internal static class LASafetyTBuilder
    {
        public static IEnumerable<SafetyT> Build(LASafetyRows laSafetyRows, IEnumerable<SafetyDiagram> safetyDiagrams)
        {
            return safetyDiagrams.Select(safetyDiagram =>
            {
                var maxRangeStandardConditionsRow = laSafetyRows.LASafetyRowStandardConditions.Single(x => x.Range == safetyDiagram.MaxRange);
                var minRangeStandardConditionsRow = laSafetyRows.LASafetyRowStandardConditions.Single(x => x.Range == safetyDiagram.MinRange);
                var minTimeRangeStandConditionsRow = laSafetyRows.LASafetyRowStandardConditions.SingleOrDefault(x => x.IsMinTimeRange);
                var minRangeNonStandardConditionsRow = laSafetyRows.LASafetyDataNonStandardConditions.Single(x => x.Range == safetyDiagram.MinRange);

                if (minTimeRangeStandConditionsRow != null)
                {
                    var minTimeRangeNonStandConditionsRow = laSafetyRows.LASafetyDataNonStandardConditions.SingleOrDefault(x => x.IsMinTimeRange);
                    return new SafetyT(
                        maxRangeStandardConditionsRow.QuadrantElevation,
                        safetyDiagram.Deflections,
                        minRangeStandardConditionsRow.QuadrantElevation,
                        minRangeNonStandardConditionsRow.QuadrantElevation,
                        minTimeRangeStandConditionsRow.TimeOfFlight,
                        minTimeRangeNonStandConditionsRow.TI,
                        minTimeRangeStandConditionsRow.VT);
                }

                return new SafetyT(
                    maxRangeStandardConditionsRow.QuadrantElevation,
                    safetyDiagram.Deflections,
                    minRangeStandardConditionsRow.QuadrantElevation,
                    minRangeNonStandardConditionsRow.QuadrantElevation,
                    minRangeStandardConditionsRow.TimeOfFlight,
                    minRangeNonStandardConditionsRow.TI,
                    minRangeStandardConditionsRow.VT);
            });
        }
    }
}
