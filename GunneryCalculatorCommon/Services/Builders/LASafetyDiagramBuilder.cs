using GunneryCalculatorCommon.Exceptions;
using GunneryCalculatorCommon.Models;
using GunneryCalculatorCommon.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GunneryCalculatorCommon.Services.Builders
{
    internal static class LASafetyDiagramBuilder
    {
        public static IEnumerable<SafetyDiagram> Build(
            IEnumerable<SafetyDiagramSection> safetyDiagramSections, 
            IEnumerable<LASafetyRowStandardCondition> laSafetyRows)
        {
            var aof = GunneryHelper.CaculateAzimuthOfFire(safetyDiagramSections);
            return safetyDiagramSections.GroupBy(x => x.LeftLimit).Select(safetyDiagramSection =>
            {
                var minRange = safetyDiagramSection.Min(x => x.Range);
                var maxRange = safetyDiagramSection.Max(x => x.Range);

                if (safetyDiagramSection.Count() > 3)
                {
                    throw new SafetyException(
                        $@"For safety digram section with min range: {minRange}, max range: {maxRange}
                         left limit: {safetyDiagramSection.First().LeftLimit}, right limit: {safetyDiagramSections.First().RightLimit} contained more sections than 3 sections. 
                         It contained {safetyDiagramSections.Count()} sections.");
                }

                var minRangeRow = laSafetyRows.Single(x => x.Range == minRange && !x.IsMinTimeRange);
                var minTimeRange = laSafetyRows.SingleOrDefault(x => x.IsMinTimeRange);
                var maxRangeRow = laSafetyRows.Single(x => x.Range == maxRange);
                var minRangeDiagramSection = safetyDiagramSection.Single(x => x.Range == minRange && !x.IsMinTimeRange);
                var minTimeRangeDiagramSection = safetyDiagramSection.SingleOrDefault(x => x.IsMinTimeRange);
                var maxRangeRowDiagramSection = safetyDiagramSection.Single(x => x.Range == maxRange);


                var deflections = GunneryHelper.CaculateDeflections(aof, minRangeDiagramSection.LeftLimit, minRangeDiagramSection.RightLimit, minRangeRow.Drift, maxRangeRow.Drift);
                return new SafetyDiagram(deflections, aof, minRange, minRangeDiagramSection.Altitude, minTimeRange == null ? minRange : minTimeRange.Range, maxRange, maxRangeRowDiagramSection.Altitude);
            });
        }
    }
}
