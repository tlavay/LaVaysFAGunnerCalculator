using GunneryCalculatorCommon.Exceptions;
using GunneryCalculatorCommon.Models.Enums;
using GunneryCalculatorCommon.Models.TFTs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace GunneryCalculatorCommon.Services.Helpers
{
    public static class TFTHelper
    {
        public static TableGolf GetTableGolfRow(IEnumerable<TableGolf> tableGolfRows, TFT tft, AngleOfFire angleOfFire, Charge charge, int range)
        {
            var filteredTableGolf = tableGolfRows.Where(x => x.TFT == tft && x.AngleOfFire == angleOfFire && x.Charge == charge);
            var tableGolf = filteredTableGolf.Where(x => x.Range == range);
            if (tableGolf.Count() == 0)
            {
                var lowerRange = filteredTableGolf.Where(x => x.Range < range).OrderBy(x => x.Range).Last();
                var higherRange = filteredTableGolf.Where(x => x.Range > range).First();

                return new TableGolf(
                    tft: lowerRange.TFT,
                    charge: charge,
                    angleOfFire: angleOfFire,
                    range: range,
                    elevation: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.Elevation, higherRange.Elevation, FAExpressTo.Tenths),
                    probErrorsR: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.ProbErrorsR, higherRange.ProbErrorsR, FAExpressTo.Whole),
                    probErrorsD: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.ProbErrorsD, higherRange.ProbErrorsD, FAExpressTo.Whole),
                    probErrorsHB: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.ProbErrorsHB, higherRange.ProbErrorsHB, FAExpressTo.Whole),
                    probErrorsTB: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.ProbErrorsTB, higherRange.ProbErrorsTB, FAExpressTo.Hundredths),
                    probErrorsRB: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.ProbErrorsRB, higherRange.ProbErrorsRB, FAExpressTo.Tenths),
                    angleOfFall: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.AngleOfFall, higherRange.AngleOfFall, FAExpressTo.Tenths),
                    cotAngleOfFall: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.CotAngleOfFall, higherRange.CotAngleOfFall, FAExpressTo.Tenths),
                    tmlVel: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.TmlVel, higherRange.TmlVel, FAExpressTo.Whole),
                    mo: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.MO, higherRange.MO, FAExpressTo.Whole),
                    posCSF: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.PosCSF, higherRange.PosCSF, FAExpressTo.Thousandths),
                    negCSF: InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.NegCSF, higherRange.NegCSF, FAExpressTo.Thousandths)); ;
            }

            return tableGolf.Single();
        }

        public static TableFox GetTableFoxRow(IEnumerable<TableFox> tableFoxRows, TFT tft, AngleOfFire angleOfFire, Charge charge, int range)
        {
            var filteredTableFox = tableFoxRows.Where(x => x.TFT == tft && x.AngleOfFire == angleOfFire && x.Charge == charge);
            var tableFox = filteredTableFox.Where(x => x.Range == range);
            if (tableFox.Count() == 0)
            {
                //AHHHHH
                //Need to update for HA
                //Order by will change by angle of fire....
                var lowerRanges = filteredTableFox.Where(x => x.Range < range).OrderBy(x => x.Range);
                TableFox lowerRange = null;
                if (!lowerRanges.Any())
                {
                    lowerRange = filteredTableFox.OrderBy(x => x.Range).Last();
                }

                var higherRange = filteredTableFox.Where(x => x.Range > range).First();

                return BuildTableFox(lowerRange, higherRange, tft, angleOfFire, charge, range);
            }

            return tableFox.Single();
        }

        private static TableFox BuildTableFox(TableFox lowerRange, TableFox higherRange, TFT tft, AngleOfFire angleOfFire, Charge charge, int range)
        {
            var elevation = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.Elevation, higherRange.Elevation, FAExpressTo.Tenths);
            var fsForGrazeBurstFuzeM582 = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.FsForGrazeBurstFuzeM582, higherRange.FsForGrazeBurstFuzeM582, FAExpressTo.Tenths);
            var dfsPer10MDecHob = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.DfsPer10MDecHob, higherRange.DfsPer10MDecHob, FAExpressTo.Hundredths);
            var drPer1MilDElev = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.DrPer1MilDElev, higherRange.DrPer1MilDElev, FAExpressTo.Whole);
            var fork = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.Fork, higherRange.Fork, FAExpressTo.Whole);
            var tof = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.TOF, higherRange.TOF, FAExpressTo.Tenths);
            var drift = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.Drift, higherRange.Drift, FAExpressTo.Tenths);
            var cwOf1Knot = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.CwOf1Knot, higherRange.CwOf1Knot, FAExpressTo.Hundredths);
            var muzzleVelocity1Dec = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.MuzzleVelocity1Dec, higherRange.MuzzleVelocity1Dec, FAExpressTo.Tenths);
            var muzzleVelocity1Inc = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.MuzzleVelocity1Inc, higherRange.MuzzleVelocity1Inc, FAExpressTo.Tenths);
            var rangeWind1KnotHead = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.RangeWind1KnotHead, higherRange.RangeWind1KnotHead, FAExpressTo.Tenths);
            var rangeWind1KnotTail = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.RangeWind1KnotTail, higherRange.RangeWind1KnotTail, FAExpressTo.Tenths);
            var airTemp1PctDec = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.AirTemp1PctDec, higherRange.AirTemp1PctDec, FAExpressTo.Tenths);
            var airTemp1PctInc = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.AirTemp1PctInc, higherRange.AirTemp1PctInc, FAExpressTo.Tenths);
            var airDensity1PctDec = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.AirDensity1PctDec, higherRange.AirDensity1PctDec, FAExpressTo.Tenths);
            var airDensity1PctInc = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.AirDensity1PctInc, higherRange.AirDensity1PctInc, FAExpressTo.Tenths);
            var projWTof1SQDec = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.ProjWTof1SQDec, higherRange.ProjWTof1SQDec, FAExpressTo.Whole);
            var projWTof1SQInc = InterpolationHelper.Interpolate(lowerRange.Range, range, higherRange.Range, lowerRange.ProjWTof1SQInc, higherRange.ProjWTof1SQInc, FAExpressTo.Whole);

            return new TableFox(
                    tft: tft,
                    charge: charge,
                    angleOfFire: angleOfFire,
                    range: range,
                    elevation: elevation,
                    fsForGrazeBurstFuzeM582: fsForGrazeBurstFuzeM582,
                    dfsPer10MDecHob: dfsPer10MDecHob,
                    drPer1MilDElev: drPer1MilDElev,
                    fork: fork,
                    tof: tof,
                    drift: drift,
                    cwOf1Knot: cwOf1Knot,
                    muzzleVelocity1Dec: muzzleVelocity1Dec,
                    muzzleVelocity1Inc: muzzleVelocity1Inc,
                    rangeWind1KnotHead: rangeWind1KnotHead,
                    rangeWind1KnotTail: rangeWind1KnotTail,
                    airTemp1PctDec: airTemp1PctDec,
                    airTemp1PctInc: airTemp1PctInc,
                    airDensity1PctDec: airDensity1PctDec,
                    airDensity1PctInc: airDensity1PctInc,
                    projWTof1SQDec: projWTof1SQDec,
                    projWTof1SQInc: projWTof1SQInc);
        }
    }
}
