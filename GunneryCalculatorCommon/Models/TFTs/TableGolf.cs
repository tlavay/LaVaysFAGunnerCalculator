﻿using GunneryCalculatorCommon.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models.TFTs
{
    public class TableGolf
    {
        public Enums.TFT TFT { get; }
        public Charge Charge { get; }
        public AngleOfFire AngleOfFire { get; }
        public int Range { get; }
        public decimal Elevation { get; }
        public decimal ProbErrorsR { get; }
        public decimal ProbErrorsD { get; }
        public decimal ProbErrorsHB { get; }
        public decimal ProbErrorsTB { get; }
        public decimal ProbErrorsRB { get; }
        public decimal AngleOfFall { get; }
        public decimal CotAngleOfFall { get; }
        public decimal TmlVel { get; }
        public decimal MO { get; }
        public decimal PosCSF { get; }
        public decimal NegCSF { get; }

        public TableGolf(
            TFT tft,
            Charge charge,
            AngleOfFire angleOfFire,
            int range,
            decimal elevation,
            decimal probErrorsR,
            decimal probErrorsD,
            decimal probErrorsHB,
            decimal probErrorsTB,
            decimal probErrorsRB,
            decimal angleOfFall,
            decimal cotAngleOfFall,
            decimal tmlVel,
            decimal mo,
            decimal posCSF,
            decimal negCSF)
        {
            this.TFT = tft;
            this.Charge = charge;
            this.AngleOfFire = angleOfFire;
            this.Range = range;
            this.Elevation = elevation;
            this.ProbErrorsR = probErrorsR;
            this.ProbErrorsD = probErrorsD;
            this.ProbErrorsHB = probErrorsHB;
            this.ProbErrorsTB = probErrorsTB;
            this.ProbErrorsRB = probErrorsRB;
            this.AngleOfFall = angleOfFall;
            this.CotAngleOfFall = cotAngleOfFall;
            this.TmlVel = tmlVel;
            this.MO = mo;
            this.PosCSF = posCSF;
            this.NegCSF = negCSF;
        }
    }
}
