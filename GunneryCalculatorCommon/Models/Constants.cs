using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models
{
    public static class Constants
    {
        /// <summary>
        /// The smart guy factor is how we convert from actual mils in circle 6283 to easy 6400
        /// </summary>
        public static decimal SmartGuyFactor = 1.0186m;
        public static int CommonDeflection = 3200;
        public static int MaxMils = 6400;
        public static decimal VTAddition = 5.5m;
        public static int StdSquareWeight = 4;
        public static int NonStdSquareWeight = 8;
    }
}
