using GunneryCalculator.Common.Exceptions;
using GunneryCalculator.Common.Models;
using GunneryCalculator.Common.Models.Enums;
using GunneryCalculator.Common.Services.Helpers;
using System;

namespace GunneryCalculator.Common.Services.Helpers
{
    internal static class SiteHelper
    {
        public static int FindSite(TabularFiringTables tabularFiringTables, int btryAlt, int tgtAlt, int range, Charge charge, AngleOfFire angleOfFire, TFT tft)
        {
            if (btryAlt == tgtAlt)
            {
                return 0;
            }

            if (range == 0)
            {
                throw new SiteException("Range cannot be 0 when attempting to find site.");
            }

            if (angleOfFire == AngleOfFire.HA)
            {
                return FindHighAngleSite(tabularFiringTables, btryAlt, tgtAlt, range, charge, tft);
            }

            return FindLowAngleSite(tabularFiringTables, btryAlt, tgtAlt, range, charge, tft);
        }

        public static int FindVI(int btryAlt, int tgtAlt)
        {
            return (int)GunneryHelper.Express(tgtAlt - btryAlt, FAExpressTo.Whole);
        }

        private static int FindLowAngleSite(TabularFiringTables tabularFiringTables, int btryAlt, int tgtAlt, int range, Charge charge, TFT tft)
        {
            var vi = FindVI(btryAlt, tgtAlt);
            var angleOfSite = FindAngleOfSite(vi, range);
            var targetOrientation = vi >= 0 ? TargetOrientation.TargetAboveGun : TargetOrientation.TargetBelowGun;
            var cas = FindComplementaryAngleOfSite(tabularFiringTables, angleOfSite, range, AngleOfFire.LA, charge, tft, targetOrientation);
            var lowAngleSite = angleOfSite + cas;
            return (int)GunneryHelper.Express(lowAngleSite, FAExpressTo.Whole);
        }

        private static int FindHighAngleSite(TabularFiringTables tabularFiringTables, int btryAlt, int tgtAlt, int range, Charge charge, TFT tft)
        {
            var vi = FindVI(btryAlt, tgtAlt);
            var angleOfSite = FindAngleOfSite(vi, range);
            var targetOrientation = vi >= 0 ? TargetOrientation.TargetAboveGun : TargetOrientation.TargetBelowGun;
            var _10MilSiteFactor = Find10MilSiteFactor(tabularFiringTables, range, AngleOfFire.HA, charge, tft, targetOrientation);
            var highAngleSite = (angleOfSite / 10) * _10MilSiteFactor;
            return (int)GunneryHelper.Express(highAngleSite, FAExpressTo.Whole);
        }

        private static decimal FindAngleOfSite(decimal vi, int range)
        {
            var rangeIn1000s = range / 1000;
            var result = (vi / rangeIn1000s) * Constants.SmartGuyFactor;
            return GunneryHelper.Express(result, FAExpressTo.Tenths);
        }

        private static decimal Find10MilSiteFactor(TabularFiringTables tabularFiringTables, int range, AngleOfFire angleOfFire, Charge charge, TFT tft, TargetOrientation targetOrientation)
        {
            var csf = GetComplementarySiteFactor(tabularFiringTables, range, angleOfFire, charge, tft, targetOrientation);
            decimal tenMilSiteFactor;
            if (targetOrientation == TargetOrientation.TargetAboveGun)
            {
                tenMilSiteFactor = 10 * (1 + csf);
            }
            else
            {
                tenMilSiteFactor = 10 * (1 - csf);
            }

            return GunneryHelper.Express(tenMilSiteFactor, FAExpressTo.Tenths);
        }

        private static decimal FindComplementaryAngleOfSite(TabularFiringTables tabularFiringTables, decimal angleOfSite, int range, AngleOfFire angleOfFire, Charge charge, TFT tft, TargetOrientation targetOrientation)
        {
            var csf = GetComplementarySiteFactor(tabularFiringTables, range, angleOfFire, charge, tft, targetOrientation);
            return GunneryHelper.Express(Math.Abs(angleOfSite) * csf, FAExpressTo.Thousandths);
        }

        private static decimal GetComplementarySiteFactor(TabularFiringTables tabularFiringTables, int range, AngleOfFire angleOfFire, Charge charge, TFT tft, TargetOrientation targetOrientation)
        {
            if (!TFTHelper.IsRangable(tabularFiringTables.TableGolf, tft, angleOfFire, charge, range))
            {
                throw new SiteException($"HA Site can not be calculated for range: {range}, charge: {charge}, tft: {tft}.");
            }

            var tableGolf = TFTHelper.GetTableGolfRow(tabularFiringTables.TableGolf, tft, angleOfFire, charge, range);
            if (targetOrientation == TargetOrientation.TargetAboveGun)
            {
                return tableGolf.PosCSF;
            }

            return tableGolf.NegCSF;
        }
    }
}
