using GunneryCalculator.Common.Exceptions;
using GunneryCalculator.Common.Models;
using GunneryCalculator.Common.Models.Enums;
using GunneryCalculator.Common.Models.Safety;
using GunneryCalculator.Common.Models.TFTs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GunneryCalculator.Common.Services.Helpers
{
    internal static class SafetyHelper
    {
        public static IEnumerable<SafetyDiagram> BuildSafetyDiagram(
            IEnumerable<SafetyDiagramSection> safetyDiagramSections,
            IEnumerable<LASafetyRowStandardCondition> laSafetyRows,
            IEnumerable<HASafetyRowDataStandardCondition> haSafetyRows)
        {
            var aof = GunneryHelper.CaculateAzimuthOfFire(safetyDiagramSections);
            var safetyDiagrams = new List<SafetyDiagram>();
            foreach (var safetyDiagramSection in safetyDiagramSections.GroupBy(x => x.LeftLimit))
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

                var minRangeDiagramSection = safetyDiagramSection.Single(x => x.Range == minRange && !x.IsMinTimeRange);
                var minTimeRangeDiagramSection = safetyDiagramSection.SingleOrDefault(x => x.IsMinTimeRange);
                var maxRangeRowDiagramSection = safetyDiagramSection.Single(x => x.Range == maxRange);

                if (laSafetyRows.Any())
                {
                    var laMinRangeRow = laSafetyRows.Single(x => x.Range == minRange && !x.IsMinTimeRange);
                    var laMinTimeRange = laSafetyRows.SingleOrDefault(x => x.IsMinTimeRange);
                    var laMaxRangeRow = laSafetyRows.Single(x => x.Range == maxRange);
                    var laDeflections = GunneryHelper.CaculateDeflections(AngleOfFire.Low, aof, minRangeDiagramSection.LeftLimit, minRangeDiagramSection.RightLimit, laMinRangeRow.Drift, laMaxRangeRow.Drift);
                    safetyDiagrams.Add(new SafetyDiagram(laDeflections, aof, minRange, minRangeDiagramSection.Altitude, laMinTimeRange == null ? minRange : laMinTimeRange.Range, maxRange, maxRangeRowDiagramSection.Altitude));
                }

                if (haSafetyRows.Any())
                {
                    var haMinRangeRow = haSafetyRows.Single(x => x.Range == minRange && !x.IsMinTimeRange);
                    var haMaxRangeRow = haSafetyRows.Single(x => x.Range == maxRange);
                    var haDeflections = GunneryHelper.CaculateDeflections(AngleOfFire.High, aof, minRangeDiagramSection.LeftLimit, minRangeDiagramSection.RightLimit, haMaxRangeRow.Drift, haMinRangeRow.Drift);
                    safetyDiagrams.Add(new SafetyDiagram(haDeflections, aof, minRange, minRangeDiagramSection.Altitude, 0, maxRange, maxRangeRowDiagramSection.Altitude));
                }
            }

            return safetyDiagrams;
        } 

        public static SafetyRows BuildSafetyRows(
            IEnumerable<SafetyDiagramSection> safetyDiagramSections,
            TFT tft,
            Charge charge,
            TabularFiringTables tabularFiringTables,
            int btryAlt)
        {
            var laSafetyRows = new List<LASafetyRowStandardCondition>();
            var laSafetyRowsForNonStandardConditions = new List<LASafetyDataNonStandardCondition>();
            var haSafetyRowsForStandardConditions = new List<HASafetyRowDataStandardCondition>();

            foreach (var safetyDiagramSection in safetyDiagramSections)
            {
                if (safetyDiagramSection.AngleOfFire == AngleOfFire.Low)
                {
                    var laTableFox = TFTHelper.GetTableFoxRow(tabularFiringTables.TableFox, tft, AngleOfFire.Low, charge, safetyDiagramSection.Range);
                    var laSite = SiteHelper.FindSite(
                        tabularFiringTables,
                        btryAlt,
                        safetyDiagramSection.Altitude,
                        safetyDiagramSection.Range,
                        charge,
                        AngleOfFire.Low,
                        tft);

                    laSafetyRows.Add(BuildLASafetyRowStandardCondition(safetyDiagramSection, laTableFox, btryAlt, laSite));
                    laSafetyRowsForNonStandardConditions.Add(BuildLASafetyDataNonStandardCondition(safetyDiagramSection, laTableFox, tabularFiringTables.TableFox, tft, charge, laSite));
                }
                else if (safetyDiagramSection.AngleOfFire == AngleOfFire.High)
                {
                    var haTableFox = TFTHelper.GetTableFoxRow(tabularFiringTables.TableFox, tft, AngleOfFire.High, charge, safetyDiagramSection.Range);
                    haSafetyRowsForStandardConditions.Add(BuildHASafetyRowsForStandardConditions(safetyDiagramSection, haTableFox, tft, charge, tabularFiringTables, btryAlt));
                }
            }

            return new SafetyRows(laSafetyRows, laSafetyRowsForNonStandardConditions, haSafetyRowsForStandardConditions);
        }

        public static IEnumerable<SafetyT> BuildSafetyTs(SafetyRows safetyRows, IEnumerable<SafetyDiagram> safetyDiagrams)
        {
            var safetyTs = new List<SafetyT>();
            foreach (var safetyDiagram in safetyDiagrams)
            {
                if (safetyDiagram.Deflections.AngleOfFire == AngleOfFire.Low)
                {
                    var laMaxRangeStandardConditionsRow = safetyRows.LASafetyRowStandardConditions.Single(x => x.Range == safetyDiagram.MaxRange);
                    var laMinRangeStandardConditionsRow = safetyRows.LASafetyRowStandardConditions.Single(x => x.Range == safetyDiagram.MinRange);
                    var laMinTimeRangeStandConditionsRow = safetyRows.LASafetyRowStandardConditions.SingleOrDefault(x => x.IsMinTimeRange);
                    var laMinRangeNonStandardConditionsRow = safetyRows.LASafetyDataNonStandardConditions.Single(x => x.Range == safetyDiagram.MinRange);

                    if (laMinTimeRangeStandConditionsRow != null)
                    {
                        var minTimeRangeNonStandConditionsRow = safetyRows.LASafetyDataNonStandardConditions.SingleOrDefault(x => x.IsMinTimeRange);
                        safetyTs.Add(new SafetyT(
                            AngleOfFire.Low,
                            laMaxRangeStandardConditionsRow.QuadrantElevation,
                            safetyDiagram.Deflections,
                            laMinRangeStandardConditionsRow.QuadrantElevation,
                            laMinRangeNonStandardConditionsRow.QuadrantElevation,
                            laMinTimeRangeStandConditionsRow.TimeOfFlight,
                            minTimeRangeNonStandConditionsRow.TimeOfFlight,
                            laMinTimeRangeStandConditionsRow.VT));
                    }

                    safetyTs.Add(new SafetyT(
                        AngleOfFire.Low,
                        laMaxRangeStandardConditionsRow.QuadrantElevation,
                        safetyDiagram.Deflections,
                        laMinRangeStandardConditionsRow.QuadrantElevation,
                        laMinRangeNonStandardConditionsRow.QuadrantElevation,
                        laMinRangeStandardConditionsRow.TimeOfFlight,
                        laMinRangeNonStandardConditionsRow.TimeOfFlight,
                        laMinRangeStandardConditionsRow.VT));
                }
                else
                {
                    var haMaxRangeStandardConditionsRow = safetyRows.HASafetyRowDataStandardCondition.Single(x => x.Range == safetyDiagram.MaxRange);
                    var haMinRangeStandardConditionsRow = safetyRows.HASafetyRowDataStandardCondition.Single(x => x.Range == safetyDiagram.MinRange);
                    safetyTs.Add(new SafetyT(AngleOfFire.High,
                        haMinRangeStandardConditionsRow.QuadrantElevation,
                        safetyDiagram.Deflections,
                        haMaxRangeStandardConditionsRow.QuadrantElevation,
                        0,
                        0,
                        0,
                        0.0m));
                }
            }

            return safetyTs;
        }

        private static LASafetyRowStandardCondition BuildLASafetyRowStandardCondition(
            SafetyDiagramSection safetyDiagramSection,
            TableFox tableFox,
            int btryAlt,
            int site)
        {
            var qe = GunneryHelper.Express(tableFox.Elevation, FAExpressTo.Whole) + site;
            return new LASafetyRowStandardCondition(
                safetyDiagramSection.Range,
                safetyDiagramSection.IsMinTimeRange,
                site,
                (int)GunneryHelper.Express(tableFox.Elevation, FAExpressTo.Whole),
                (int)GunneryHelper.Express(qe, FAExpressTo.Whole),
                (int)GunneryHelper.Express(tableFox.Drift, FAExpressTo.Whole),
                tableFox.TOF,
                SiteHelper.FindVI(btryAlt, safetyDiagramSection.Altitude),
                Math.Ceiling(tableFox.TOF + Constants.VTAddition));
        }

        private static LASafetyDataNonStandardCondition BuildLASafetyDataNonStandardCondition(
            SafetyDiagramSection safetyDiagramSection,
            TableFox tableFox,
            IEnumerable<TableFox> tableFoxes,
            TFT tft,
            Charge charge,
            int site)
        {
            var rangeCorrectionNotExpressed = (Constants.NonStdSquareWeight - Constants.StdSquareWeight) * tableFox.ProjWTof1SQInc;
            var rangeCorrection = (int)GunneryHelper.Express(rangeCorrectionNotExpressed, FAExpressTo.Tens);

            var tableFoxRangeCorrection = TFTHelper.GetTableFoxRow(tableFoxes, tft, AngleOfFire.Low, charge, rangeCorrection + safetyDiagramSection.Range);

            var elevation = (int)GunneryHelper.Express(tableFoxRangeCorrection.Elevation, FAExpressTo.Whole);
            var quadrantElevationNonStandard = elevation + site;
            return new LASafetyDataNonStandardCondition(
                safetyDiagramSection.Range,
                safetyDiagramSection.IsMinTimeRange,
                site,
                elevation,
                quadrantElevationNonStandard,
                (int)GunneryHelper.Express(tableFox.Drift, FAExpressTo.Whole),
                tableFoxRangeCorrection.TOF,
                rangeCorrection,
                rangeCorrection + safetyDiagramSection.Range);
        }

        private static HASafetyRowDataStandardCondition BuildHASafetyRowsForStandardConditions(
            SafetyDiagramSection safetyDiagramSection,
            TableFox tableFox,
            TFT tft,
            Charge charge,
            TabularFiringTables tabularFiringTables,
            int btryAlt)
        {
            var site = SiteHelper.FindSite(
                    tabularFiringTables,
                    btryAlt,
                    safetyDiagramSection.Altitude,
                    safetyDiagramSection.Range,
                    charge,
                    AngleOfFire.High,
                    tft);

            var qe = GunneryHelper.Express(tableFox.Elevation, FAExpressTo.Whole) + site;
            return new HASafetyRowDataStandardCondition(
                safetyDiagramSection.Range,
                false,
                (int)GunneryHelper.Express(qe, FAExpressTo.Whole),
                (int)tableFox.Elevation,
                (int)qe,
                (int)tableFox.Drift,
                0.0m);
        }
    }
}
