using System;
using Xunit;
using GunneryCalculator.Common.Services.Extensions;
using GunneryCalculator.Common.Models.Enums;
using GunneryCalculator.Common.Services.Helpers;
using GunneryCalculator.Common.Models;
using System.Collections.Generic;
using FluentAssertions;
using GunneryCalculator.Common.Models.Safety;

namespace GunneryCalculator.Common.Tests
{
    public class FAExpressExtenstionTest
    {
        [Fact]
        public void GunneryHelper_Express_ExpressToNearestWhole_ShouldExpressToNearstWhole()
        {
            //Arrange
            var expectedResult = 2;
            var input1 = 1.5m;
            var input2 = 2.5m;
            var input3 = 2.4m;
            var input4 = 2.51m;

            //Act
            var result1 = GunneryHelper.Express(input1, FAExpressTo.Whole);
            var result2 = GunneryHelper.Express(input2, FAExpressTo.Whole);
            var result3 = GunneryHelper.Express(input3, FAExpressTo.Whole);
            var result4 = GunneryHelper.Express(input4, FAExpressTo.Whole);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(3, result4);
        }

        [Fact]
        public void GunneryHelper_Express_ExpressToNearestTens_ShouldExpressToNearstTens()
        {
            //Arrange
            var expectedResult = 20m;
            var input1 = 15m;
            var input2 = 25m;
            var input3 = 24m;
            var input4 = 26m;

            //Act
            var result1 = GunneryHelper.Express(input1,FAExpressTo.Tens);
            var result2 = GunneryHelper.Express(input2, FAExpressTo.Tens);
            var result3 = GunneryHelper.Express(input3, FAExpressTo.Tens);
            var result4 = GunneryHelper.Express(input4, FAExpressTo.Tens);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(30, result4);
        }

        [Fact]
        public void GunneryHelper_Express_ExpressToNearestHundreds_ShouldExpressToNearstHundreds()
        {
            //Arrange
            var expectedResult = 200m;
            var input1 = 150m;
            var input2 = 250m;
            var input3 = 240m;
            var input4 = 260m;

            //Act
            var result1 = GunneryHelper.Express(input1,FAExpressTo.Hundreds);
            var result2 = GunneryHelper.Express(input2, FAExpressTo.Hundreds);
            var result3 = GunneryHelper.Express(input3, FAExpressTo.Hundreds);
            var result4 = GunneryHelper.Express(input4, FAExpressTo.Hundreds);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(300, result4);
        }

        [Fact]
        public void GunneryHelper_Express_ExpressToNearestThousands_ShouldExpressToNearstThousands()
        {
            //Arrange
            var expectedResult = 2000m;
            var input1 = 1500m;
            var input2 = 2500m;
            var input3 = 2400m;
            var input4 = 2600m;

            //Act
            var result1 = GunneryHelper.Express(input1,FAExpressTo.Thousands);
            var result2 = GunneryHelper.Express(input2, FAExpressTo.Thousands);
            var result3 = GunneryHelper.Express(input3, FAExpressTo.Thousands);
            var result4 = GunneryHelper.Express(input4, FAExpressTo.Thousands);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(3000, result4);
        }

        [Fact]
        public void GunneryHelper_Express_ExpressToNearestTenths_ShouldExpressToNearstTenths()
        {
            //Arrange
            var expectedResult = 0.6m;
            var input1 = 0.55m;
            var input2 = 0.65m;
            var input3 = 0.56m;
            var input4 = 0.66m;

            //Act
            var result1 = GunneryHelper.Express(input1,FAExpressTo.Tenths);
            var result2 = GunneryHelper.Express(input2, FAExpressTo.Tenths);
            var result3 = GunneryHelper.Express(input3, FAExpressTo.Tenths);
            var result4 = GunneryHelper.Express(input4, FAExpressTo.Tenths);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(0.7m, result4);
        }

        [Fact]
        public void GunneryHelper_Express_ExpressToNearestHundredths_ShouldExpressToNearstHundredths()
        {
            //Arrange
            var expectedResult = 0.02m;
            var input1 = 0.025m;
            var input2 = 0.015m;
            var input3 = 0.024m;
            var input4 = 0.026m;

            //Act
            var result1 = GunneryHelper.Express(input1,FAExpressTo.Hundredths);
            var result2 = GunneryHelper.Express(input2, FAExpressTo.Hundredths);
            var result3 = GunneryHelper.Express(input3, FAExpressTo.Hundredths);
            var result4 = GunneryHelper.Express(input4, FAExpressTo.Hundredths);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(0.03m, result4);
        }

        [Fact]
        public void GunneryHelper_Express_ExpressToNearestThousandths_ShouldExpressToNearstThousandths()
        {
            //Arrange
            var expectedResult = 0.002m;
            var input1 = 0.0025m;
            var input2 = 0.0015m;
            var input3 = 0.0024m;
            var input4 = 0.0026m;

            //Act
            var result1 = GunneryHelper.Express(input1,FAExpressTo.Thousandths);
            var result2 = GunneryHelper.Express(input2, FAExpressTo.Thousandths);
            var result3 = GunneryHelper.Express(input3, FAExpressTo.Thousandths);
            var result4 = GunneryHelper.Express(input4, FAExpressTo.Thousandths);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(0.003m, result4);
        }

        [Fact]
        public void GunneryHelper_Express_ExpressToNearestTenThousandths_ShouldExpressToNearstTenThousandths()
        {
            //Arrange
            var expectedResult = 0.0002m;
            var input1 = 0.00025m;
            var input2 = 0.00015m;
            var input3 = 0.00024m;
            var input4 = 0.00026m;

            //Act
            var result1 = GunneryHelper.Express(input1,FAExpressTo.TenThousandths);
            var result2 = GunneryHelper.Express(input2, FAExpressTo.TenThousandths);
            var result3 = GunneryHelper.Express(input3, FAExpressTo.TenThousandths);
            var result4 = GunneryHelper.Express(input4, FAExpressTo.TenThousandths);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(0.0003m, result4);
        }

        [Fact]
        public void GunneryHelper_CaculateAzimuthOfFire_WithNonTraversingValues_ShouldReturnAOF()
        {
            //Arrange
            var leftLimit = 1600;
            var rightLimit = 2200;
            var safetyDiagramSection = new SafetyDiagramSection()
            {
                LeftLimit = leftLimit,
                RightLimit = rightLimit
            };

            var expectedAOF = 1900;

            //Act
            var actualAOF = GunneryHelper.CaculateAzimuthOfFire(new List<SafetyDiagramSection>() { safetyDiagramSection });

            //Assert
            Assert.Equal(expectedAOF, actualAOF);
        }

        [Fact]
        public void GunneryHelper_CaculateAzimuthOfFire_WithTraversingValues_ShouldReturnAOFBelow6400WhichIsConvertedToZero()
        {
            //Arrange
            var leftLimit = 6250;
            var rightLimit = 200;
            var safetyDiagramSection = new SafetyDiagramSection()
            {
                LeftLimit = leftLimit,
                RightLimit = rightLimit
            };

            var expectedAOF = 0;

            //Act
            var actualAOF = GunneryHelper.CaculateAzimuthOfFire(new List<SafetyDiagramSection>() { safetyDiagramSection });

            //Assert
            Assert.Equal(expectedAOF, actualAOF);
        }

        [Fact]
        public void GunneryHelper_CaculateAzimuthOfFire_WithTraversingValues_ShouldReturnAOFAbove6400()
        {
            //Arrange
            var leftLimit = 6250;
            var rightLimit = 300;
            var safetyDiagramSection = new SafetyDiagramSection()
            {
                LeftLimit = leftLimit,
                RightLimit = rightLimit
            };

            var expectedAOF = 100;

            //Act
            var actualAOF = GunneryHelper.CaculateAzimuthOfFire(new List<SafetyDiagramSection>() { safetyDiagramSection });

            //Assert
            Assert.Equal(expectedAOF, actualAOF);
        }

        [Fact]
        public void GunneryHelper_CaculateAzimuthOfFire_WithTraversingValues_ShouldReturnAOFBelow6400()
        {
            //Arrange
            var leftLimit = 6250;
            var rightLimit = 0;
            var safetyDiagramSection = new SafetyDiagramSection()
            {
                LeftLimit = leftLimit,
                RightLimit = rightLimit
            };

            var expectedAOF = 6300;

            //Act
            var actualAOF = GunneryHelper.CaculateAzimuthOfFire(new List<SafetyDiagramSection>() { safetyDiagramSection });

            //Assert
            Assert.Equal(expectedAOF, actualAOF);
        }

        [Fact]
        public void GunneryHelper_CaculateDeflections_WithNonTraversingValues_ShouldLeftAndRightDeflection()
        {
            //Arrange
            var leftLimit = 1600;
            var rightLimit = 2200;
            var aof = 1900;
            var minDrift = 9;
            var maxDrift = 13;

            var expectedDeflections = new Deflections(AngleOfFire.Low, 3509, 2913);

            //Act
            var actualDeflections = GunneryHelper.CaculateDeflections(AngleOfFire.Low, aof, leftLimit, rightLimit, minDrift, maxDrift);

            //Assert
            actualDeflections.Should().BeEquivalentTo(expectedDeflections);
        }

        [Fact]
        public void GunneryHelper_CaculateDeflections_WithTraversingValues_ShouldLeftAndRightDeflection()
        {
            //Arrange
            var leftLimit = 6340;
            var rightLimit = 0610;
            var aof = 300;
            var minDrift = 6;
            var maxDrift = 11;

            var expectedDeflections = new Deflections(AngleOfFire.Low, 3566, 2901);

            //Act
            var actualDeflections = GunneryHelper.CaculateDeflections(AngleOfFire.Low, aof, leftLimit, rightLimit, minDrift, maxDrift);

            //Assert
            actualDeflections.Should().BeEquivalentTo(expectedDeflections);
        }
    }
}
