using System;
using Xunit;
using GunneryCalculatorCommon.Services.Extensions;
using GunneryCalculatorCommon.Models.Enums;

namespace Common.Tests
{
    public class FAExpressExtenstionTest
    {
        [Fact]
        public void FAExpressExtension_Express_ExpressToNearestWhole_ShouldExpressToNearstWhole()
        {
            //Arrange
            var expectedResult = 2;
            var input1 = 1.5m;
            var input2 = 2.5m;
            var input3 = 2.4m;
            var input4 = 2.51m;

            //Act
            var result1 = input1.Express(FAExpressTo.Whole);
            var result2 = input2.Express(FAExpressTo.Whole);
            var result3 = input3.Express(FAExpressTo.Whole);
            var result4 = input4.Express(FAExpressTo.Whole);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(3, result4);
        }

        [Fact]
        public void FAExpressExtension_Express_ExpressToNearestTens_ShouldExpressToNearstTens()
        {
            //Arrange
            var expectedResult = 20m;
            var input1 = 15m;
            var input2 = 25m;
            var input3 = 24m;
            var input4 = 26m;

            //Act
            var result1 = input1.Express(FAExpressTo.Tens);
            var result2 = input2.Express(FAExpressTo.Tens);
            var result3 = input3.Express(FAExpressTo.Tens);
            var result4 = input4.Express(FAExpressTo.Tens);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(30, result4);
        }

        [Fact]
        public void FAExpressExtension_Express_ExpressToNearestHundreds_ShouldExpressToNearstHundreds()
        {
            //Arrange
            var expectedResult = 200m;
            var input1 = 150m;
            var input2 = 250m;
            var input3 = 240m;
            var input4 = 260m;

            //Act
            var result1 = input1.Express(FAExpressTo.Hundreds);
            var result2 = input2.Express(FAExpressTo.Hundreds);
            var result3 = input3.Express(FAExpressTo.Hundreds);
            var result4 = input4.Express(FAExpressTo.Hundreds);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(300, result4);
        }

        [Fact]
        public void FAExpressExtension_Express_ExpressToNearestThousands_ShouldExpressToNearstThousands()
        {
            //Arrange
            var expectedResult = 2000m;
            var input1 = 1500m;
            var input2 = 2500m;
            var input3 = 2400m;
            var input4 = 2600m;

            //Act
            var result1 = input1.Express(FAExpressTo.Thousands);
            var result2 = input2.Express(FAExpressTo.Thousands);
            var result3 = input3.Express(FAExpressTo.Thousands);
            var result4 = input4.Express(FAExpressTo.Thousands);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(3000, result4);
        }

        [Fact]
        public void FAExpressExtension_Express_ExpressToNearestTenths_ShouldExpressToNearstTenths()
        {
            //Arrange
            var expectedResult = 0.6m;
            var input1 = 0.55m;
            var input2 = 0.65m;
            var input3 = 0.56m;
            var input4 = 0.66m;

            //Act
            var result1 = input1.Express(FAExpressTo.Tenths);
            var result2 = input2.Express(FAExpressTo.Tenths);
            var result3 = input3.Express(FAExpressTo.Tenths);
            var result4 = input4.Express(FAExpressTo.Tenths);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(0.7m, result4);
        }

        [Fact]
        public void FAExpressExtension_Express_ExpressToNearestHundredths_ShouldExpressToNearstHundredths()
        {
            //Arrange
            var expectedResult = 0.02m;
            var input1 = 0.025m;
            var input2 = 0.015m;
            var input3 = 0.024m;
            var input4 = 0.026m;

            //Act
            var result1 = input1.Express(FAExpressTo.Hundredths);
            var result2 = input2.Express(FAExpressTo.Hundredths);
            var result3 = input3.Express(FAExpressTo.Hundredths);
            var result4 = input4.Express(FAExpressTo.Hundredths);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(0.03m, result4);
        }

        [Fact]
        public void FAExpressExtension_Express_ExpressToNearestThousandths_ShouldExpressToNearstThousandths()
        {
            //Arrange
            var expectedResult = 0.002m;
            var input1 = 0.0025m;
            var input2 = 0.0015m;
            var input3 = 0.0024m;
            var input4 = 0.0026m;

            //Act
            var result1 = input1.Express(FAExpressTo.Thousandths);
            var result2 = input2.Express(FAExpressTo.Thousandths);
            var result3 = input3.Express(FAExpressTo.Thousandths);
            var result4 = input4.Express(FAExpressTo.Thousandths);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(0.003m, result4);
        }

        [Fact]
        public void FAExpressExtension_Express_ExpressToNearestTenThousandths_ShouldExpressToNearstTenThousandths()
        {
            //Arrange
            var expectedResult = 0.0002m;
            var input1 = 0.00025m;
            var input2 = 0.00015m;
            var input3 = 0.00024m;
            var input4 = 0.00026m;

            //Act
            var result1 = input1.Express(FAExpressTo.TenThousandths);
            var result2 = input2.Express(FAExpressTo.TenThousandths);
            var result3 = input3.Express(FAExpressTo.TenThousandths);
            var result4 = input4.Express(FAExpressTo.TenThousandths);

            //Assert
            Assert.Equal(expectedResult, result1);
            Assert.Equal(expectedResult, result2);
            Assert.Equal(expectedResult, result3);
            Assert.Equal(0.0003m, result4);
        }
    }
}
