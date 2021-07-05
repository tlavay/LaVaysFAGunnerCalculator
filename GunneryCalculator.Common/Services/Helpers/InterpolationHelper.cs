using GunneryCalculator.Common.Models.Enums;
using GunneryCalculator.Common.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculator.Common.Services.Helpers
{
    internal static class InterpolationHelper
    {
        /// <summary>
        /// y2 = ((x2 - x1)(y3 - y1))/(x3 - x1)) > express > result expressPartialResult + y1
        /// In FA expression we FA interpolarte the partial result before adding back into y1
        /// </summary>
        /// <param name="x1">input x1</param>
        /// <param name="x2">input x2</param>
        /// <param name="x3">input x3</param>
        /// <param name="y1">input y1</param>
        /// <param name="y3">input y3</param>
        /// <param name="expressTo">Vale to express to</param>
        /// <returns>y2</returns>
        public static decimal Interpolate(decimal x1, decimal x2, decimal x3, decimal y1, decimal y3, FAExpressTo expressTo)
        {
            var partialResult = ((x2 - x1) * (y3 - y1)) / (x3 - x1);
            var expressPartialResult = GunneryHelper.Express(partialResult, expressTo);
            return y1 + expressPartialResult;
        }

        /// <summary>
        /// y2 = ((x2 - x1)(y3 - y1))/(x3 - x1)) + y1
        /// </summary>
        /// <param name="x1">input x1</param>
        /// <param name="x2">input x2</param>
        /// <param name="x3">input x3</param>
        /// <param name="y1">input y1</param>
        /// <param name="y3">input y3</param>
        /// <param name="expressTo">Vale to express to</param>
        /// <returns>y2</returns>
        public static decimal Interpolate(decimal x1, decimal x2, decimal x3, decimal y1, decimal y3)
        {
            return Interpolate(x1, x2, x3, y1, y3, FAExpressTo.None);
        }
    }  
}
