using GunneryCalculatorCommon.Exceptions;
using GunneryCalculatorCommon.Models;
using GunneryCalculatorCommon.Models.Enums;
using GunneryCalculatorCommon.Models.TFTs;
using GunneryCalculatorCommon.Services.DataLayer;
using GunneryCalculatorCommon.Services.Extensions;
using GunneryCalculatorCommon.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GunneryCalculatorCommon.Services
{
    public class SiteService
    {
        private readonly DataService dataService;

        public SiteService(DataService dataService)
        {
            this.dataService = dataService;
        }

        public int FindSite(int btryAlt, int tgtAlt, int range, Charge charge, AngleOfFire angleOfFire, TFT tft)
        {
            if (range == 0)
            {
                throw new SiteException("Range cannot be 0 when attempting to find site.");
            }

            if (angleOfFire == AngleOfFire.HA)
            {
                return (int)FindHighAngleSite(btryAlt, tgtAlt, range, charge, tft);
            }


            return (int)FindLowAngleSite(btryAlt, tgtAlt, range, charge, tft);
        }

        private decimal FindLowAngleSite(int btryAlt, int tgtAlt, int range, Charge charge, TFT tft)
        {
            var vi = FindVI(btryAlt, tgtAlt);
            var angleOfSite = FindAngleOfSite(vi, range);
            var targetOrientation = vi >= 0 ? TargetOrientation.TargetAboveGun : TargetOrientation.TargetBelowGun;
            var cas = FindComplementaryAngleOfSite(vi, range, AngleOfFire.LA, charge, tft, targetOrientation);
            var lowAngleSite = angleOfSite + cas;
            return lowAngleSite.Express(FAExpressTo.Whole);
        }

        private decimal FindHighAngleSite(int btryAlt, int tgtAlt, int range, Charge charge, TFT tft)
        {
            var vi = FindVI(btryAlt, tgtAlt);
            var angleOfSite = FindAngleOfSite(vi, range);
            if (angleOfSite == 0)
            {
                return angleOfSite;
            }

            var targetOrientation = vi >= 0 ? TargetOrientation.TargetAboveGun : TargetOrientation.TargetBelowGun;
            var _10MilSiteFactor = Find10MilSiteFactor(vi, range, AngleOfFire.HA, charge, tft, targetOrientation);
            var highAngleSite = (angleOfSite / 10) * _10MilSiteFactor;
            return highAngleSite.Express(FAExpressTo.Whole);
        }

        private decimal FindVI(int btryAlt, int tgtAlt)
        {
            return ((decimal)tgtAlt - btryAlt).Express(FAExpressTo.Whole);
        }

        private decimal FindAngleOfSite(decimal vi, int range)
        {
            var rangeIn1000s = range / 1000;
            return ((decimal)(vi / rangeIn1000s) * Constants.SmartGuyFactor).Express(FAExpressTo.Tenths);
        }

        private decimal Find10MilSiteFactor(decimal vi, int range, AngleOfFire angleOfFire, Charge charge, TFT tft, TargetOrientation targetOrientation)
        {
            var csf = GetComplementarySiteFactor(range, angleOfFire, charge, tft, targetOrientation);
            if (targetOrientation == TargetOrientation.TargetAboveGun)
            {
                return (10 * (1 + csf)).Express(FAExpressTo.Tenths);
            }

            return (10 * (1 - csf)).Express(FAExpressTo.Tenths);
        }

        private decimal FindComplementaryAngleOfSite(decimal vi, int range, AngleOfFire angleOfFire, Charge charge, TFT tft, TargetOrientation targetOrientation)
        {
            var csf = GetComplementarySiteFactor(range, angleOfFire, charge, tft, targetOrientation);
            return (Math.Abs(vi) * csf).Express(FAExpressTo.Tenths);
        }

        private decimal GetComplementarySiteFactor(int range, AngleOfFire angleOfFire, Charge charge, TFT tft, TargetOrientation targetOrientation)
        {
            var tfts = this.dataService.GetTabularFiringTables(tft);
            var tableGolf = TFTHelper.GetTableGolfRow(tfts.TableGolf, tft, angleOfFire, charge, range);
            if (targetOrientation == TargetOrientation.TargetAboveGun)
            {
                return tableGolf.PosCSF;
            }

            return tableGolf.NegCSF;
        }
    }
}
