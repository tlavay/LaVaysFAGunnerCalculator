using GunneryCalculatorCommon.Models.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GunneryCalculatorCommon.Exceptions;
using GunneryCalculatorCommon.Models;
using System.Linq;
using GunneryCalculatorCommon.Models.Safety;

[assembly: InternalsVisibleToAttribute("Common.Tests")]
namespace GunneryCalculatorCommon.Services.Helpers
{
    internal static class GunneryHelper
    {
        public static decimal Express(decimal input, FAExpressTo expressTo)
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
                    return (int)Math.Round((decimal)input, 0, MidpointRounding.ToEven);
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
                    throw new ExpressionException($"An error occurred during expression. The FA Express To enum {expressTo} is not supported by this method (decimal).");
            }
        }

        public static int CaculateAzimuthOfFire(IEnumerable<SafetyDiagramSection> safetyDiagramSections)
        {
            var minLeftLimit = safetyDiagramSections.Min(safetyDiagramSection => safetyDiagramSection.LeftLimit);
            var maxRightLimit = safetyDiagramSections.Max(safetyDiagramSection => safetyDiagramSection.RightLimit);

            var sumOfLeftLimits = safetyDiagramSections.Sum(safetyDiagramSection => safetyDiagramSection.LeftLimit);
            var sumOfRightLimits = safetyDiagramSections.Sum(safetyDiagramSection => safetyDiagramSection.RightLimit);

            var averageAzimuth = (minLeftLimit + maxRightLimit) / 2;
            // if below is true then we know we have to handle traversing a circle
            if (sumOfLeftLimits > sumOfRightLimits)
            {
                var result = (int)Express(averageAzimuth + 3200, FAExpressTo.Hundreds);
                if (result == Constants.MaxMils)
                {
                    //6400 or 0 is correct. Deciding to standardize on 0.
                    return 0;
                }
                else if (result > Constants.MaxMils)
                {
                    return result - Constants.MaxMils;
                }

                return result;
            }

            return (int)Express(averageAzimuth, FAExpressTo.Hundreds);
        }

        public static Deflections CaculateDeflections(AngleOfFire angleOfFire, int aof, int leftLimt, int rightLimit, int minDrift, int maxDrift)
        {
            var leftDeflection = leftLimt > rightLimit ?
                (aof + Constants.MaxMils) - leftLimt + Constants.CommonDeflection + minDrift :
                aof - leftLimt + Constants.CommonDeflection + minDrift;

            var rightDeflection = aof - rightLimit + Constants.CommonDeflection + maxDrift;

            return new Deflections(angleOfFire, leftDeflection, rightDeflection);
        }

        private static int Express(decimal input, int divideBy)
        {
            decimal firstDigit = input / divideBy;
            return (int)Math.Round(firstDigit, 0, MidpointRounding.ToEven) * divideBy;
        }
    }
}
