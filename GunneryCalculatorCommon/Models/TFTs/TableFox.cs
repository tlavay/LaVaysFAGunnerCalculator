using GunneryCalculatorCommon.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models.TFTs
{
    public class TableFox
    {
        public TFT TFT { get; }
        public Charge Charge { get; }
        public AngleOfFire AngleOfFire { get; }
        public int Range { get; }
        public decimal Elevation { get; }
        public decimal FsForGrazeBurstFuzeM582 { get; }
        public decimal DfsPer10MDecHob { get; }
        public decimal DrPer1MilDElev { get; }
        public decimal Fork { get; }
        public decimal TOF { get; }
        public decimal Drift { get; }
        public decimal CwOf1Knot { get; }
        public decimal MuzzleVelocity1Dec { get; }
        public decimal MuzzleVelocity1Inc { get; }
        public decimal RangeWind1KnotHead { get; }
        public decimal RangeWind1KnotTail { get; }
        public decimal AirTemp1PctDec { get; }
        public decimal AirTemp1PctInc { get; }
        public decimal AirDensity1PctDec { get; }
        public decimal AirDensity1PctInc { get; }
        public decimal ProjWTof1SQDec { get; }
        public decimal ProjWTof1SQInc { get; }

        public TableFox(
            TFT tft,
            Charge charge,
            AngleOfFire angleOfFire,
            int range,
            decimal elevation,
            decimal fsForGrazeBurstFuzeM582,
            decimal dfsPer10MDecHob,
            decimal drPer1MilDElev,
            decimal fork,
            decimal tof,
            decimal drift,
            decimal cwOf1Knot,
            decimal muzzleVelocity1Dec,
            decimal muzzleVelocity1Inc,
            decimal rangeWind1KnotHead,
            decimal rangeWind1KnotTail,
            decimal airTemp1PctDec,
            decimal airTemp1PctInc,
            decimal airDensity1PctDec,
            decimal airDensity1PctInc,
            decimal projWTof1SQDec,
            decimal projWTof1SQInc)
        {
            this.TFT = tft;
            this.Charge = charge;
            this.AngleOfFire = angleOfFire;
            this.Range = range;
            this.Elevation = elevation;
            this.FsForGrazeBurstFuzeM582 = fsForGrazeBurstFuzeM582;
            this.DfsPer10MDecHob = dfsPer10MDecHob;
            this.DrPer1MilDElev = drPer1MilDElev;
            this.Fork = fork;
            this.TOF = tof;
            this.Drift = drift;
            this.CwOf1Knot = cwOf1Knot;
            this.MuzzleVelocity1Dec = muzzleVelocity1Dec;
            this.MuzzleVelocity1Inc = muzzleVelocity1Inc;
            this.RangeWind1KnotHead = rangeWind1KnotHead;
            this.RangeWind1KnotTail = rangeWind1KnotTail;
            this.AirTemp1PctDec = airTemp1PctDec;
            this.AirTemp1PctInc = airTemp1PctInc;
            this.AirDensity1PctDec = airDensity1PctDec;
            this.AirDensity1PctInc = airDensity1PctInc;
            this.ProjWTof1SQDec = projWTof1SQDec;
            this.ProjWTof1SQInc = projWTof1SQInc;
        }
    }
}
