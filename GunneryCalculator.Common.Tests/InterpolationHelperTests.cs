using GunneryCalculator.Common.Models.Enums;
using GunneryCalculator.Common.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GunneryCalculator.Common.Tests
{
    public class InterpolationHelperTests
    {
        [Fact]
        public void InterpolationHelper_Interpolate_WithValidInterpolationData_ShouldInterpolate()
        {
            //Arrange
            var x1 = 1;
            var x2 = 2;
            var x3 = 3;
            var y1 = 10;
            var y3 = 20;

            //Act
            var y2WholeResult = InterpolationHelper.Interpolate(x1, x2, x3, y1, y3, FAExpressTo.Whole);
            var y2NoExpress = InterpolationHelper.Interpolate(x1, x2, x3, y1, y3);
            var y2NearestTensResult = InterpolationHelper.Interpolate(x1, x2, x3, y1, y3, FAExpressTo.Tens);

            //Assert
            Assert.Equal(15, y2WholeResult);
            Assert.Equal(15, y2NoExpress);
            Assert.Equal(10, y2NearestTensResult);
        }
        [Fact]
        public void InterpolationHelper_Interpolate_WithRealInterpolationData_ShouldInterpolate()
        {
            //Arrange
            var x1 = 5400;
            var x2 = 5420;
            var x3 = 5500;
            var y1 = 15.7m;
            var y3 = 16.0m;

            //Act
            var y2 = InterpolationHelper.Interpolate(x1, x2, x3, y1, y3, FAExpressTo.Tenths);

            //Assert
            Assert.Equal(15.8m, y2);
        }
    }
}
