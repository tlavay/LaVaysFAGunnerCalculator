using GunneryCalculatorCommon.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Common.Tests")]
namespace GunneryCalculatorCommon.Services.Extensions
{
    internal static class FAExpressExtension
    {
        public static decimal Express(this decimal input, FAExpressTo expressTo)
        {
            switch (expressTo)
            {
                case FAExpressTo.None:
                    return input;
                case FAExpressTo.Thousands:
                    return Express(input, 1000);
                case FAExpressTo.Hundreds:
                    return Express(input, 100);
                case FAExpressTo.Tens:
                    return Express(input, 10);
                case FAExpressTo.Whole:
                    return Math.Round(input, 0, MidpointRounding.ToEven);
                case FAExpressTo.Tenths:
                    return Math.Round(input, 1, MidpointRounding.ToEven);
                case FAExpressTo.Hundredths:
                    return Math.Round(input, 2, MidpointRounding.ToEven);
                case FAExpressTo.Thousandths:
                    return Math.Round(input, 3, MidpointRounding.ToEven);
                case FAExpressTo.TenThousandths:
                    //box and unbox
                    return Math.Round(input, 4, MidpointRounding.ToEven);
                default:
                    return input;
            }
        }

        private static decimal Express(decimal input, int divideBy)
        {
            var firstDigit = input / divideBy;
            return Math.Round(firstDigit, 0, MidpointRounding.ToEven) * divideBy;
        }
    }
}
