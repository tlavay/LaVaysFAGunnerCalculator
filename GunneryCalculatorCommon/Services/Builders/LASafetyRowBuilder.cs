using GunneryCalculatorCommon.Models;
using GunneryCalculatorCommon.Models.Enums;
using GunneryCalculatorCommon.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Services.Builders
{
    internal static class LASafetyRowBuilder
    {
        public static LASafetyRows Build(
            IEnumerable<SafetyDiagramSection> safetyDiagramSections,
            TFT tft,
            Charge charge,
            TabularFiringTables tabularFiringTables,
            int btryAlt)
        {
            var laSafetyRows = new List<LASafetyRowStandardCondition>();
            var laSafetyRowsForNonStandardConditions = new List<LASafetyDataNonStandardCondition>();
            foreach (var safetyDiagramSection in safetyDiagramSections)
            {
                var tableFox = TFTHelper.GetTableFoxRow(tabularFiringTables.TableFox, tft, AngleOfFire.LA, charge, safetyDiagramSection.Range);

                var site = SiteHelper.FindSite(tabularFiringTables, btryAlt, safetyDiagramSection.Altitude, safetyDiagramSection.Range, charge, AngleOfFire.LA, tft);
                var qe = GunneryHelper.Express(tableFox.Elevation, FAExpressTo.Whole) + site;
                laSafetyRows.Add(new LASafetyRowStandardCondition()
                {
                    Range = safetyDiagramSection.Range,
                    VI = SiteHelper.FindVI(btryAlt, safetyDiagramSection.Altitude),
                    Site = site,
                    IsMinTimeRange = safetyDiagramSection.IsMinTimeRange,
                    Elevation = tableFox.Elevation,
                    QuadrantElevation = (int)GunneryHelper.Express(qe, FAExpressTo.Whole),
                    TimeOfFlight = tableFox.TOF,
                    VT = Math.Ceiling(tableFox.TOF + Constants.VTAddition),
                    Drift = (int)GunneryHelper.Express(tableFox.Drift, FAExpressTo.Whole)
                });

                //This will always be and increase. V2 will have to figure this out.
                var rangeCorrectionNotExpressed = (Constants.NonStdSquareWeight - Constants.StdSquareWeight) * tableFox.ProjWTof1SQInc;
                var rangeCorrection = (int)GunneryHelper.Express(rangeCorrectionNotExpressed, FAExpressTo.Tens) + safetyDiagramSection.Range;

                var tableFoxRangeCorrection = TFTHelper.GetTableFoxRow(tabularFiringTables.TableFox, tft, AngleOfFire.LA, charge, rangeCorrection);

                var elevation = GunneryHelper.Express(tableFoxRangeCorrection.Elevation, FAExpressTo.Whole);
                var quadrantElevationNonStandard = elevation + site;
                laSafetyRowsForNonStandardConditions.Add(new LASafetyDataNonStandardCondition()
                {
                    Range = safetyDiagramSection.Range,
                    RangeCorrection = rangeCorrection,
                    EntryRange = safetyDiagramSection.Range + rangeCorrection,
                    Site = site,
                    Elevation = elevation,
                    TI = tableFoxRangeCorrection.TOF,
                    QuadrantElevation = (int)quadrantElevationNonStandard
                });
            }

            return new LASafetyRows(laSafetyRows, laSafetyRowsForNonStandardConditions);
        }
    }
}
