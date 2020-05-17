using FluentAssertions;
using GunneryCalculatorCommon.Models;
using GunneryCalculatorCommon.Models.Enums;
using GunneryCalculatorCommon.Models.Safety;
using GunneryCalculatorCommon.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Common.Tests
{
    public class SafetyServiceTests
    {
        private ServiceProvider serviceProvider;

        public SafetyServiceTests()
        {
            this.serviceProvider = TestHelper.GetServiceProvider();
        }
        [Fact]
        public void SafetyService_GetLAPreOccupationSafety_WithValidInputData_ShouldComputSafety()
        {
            //Arrange
            var safetyService = this.serviceProvider.GetService<SafetyService>();
            var laSafetyInput = new LASafetyInput()
            {
                Loaction = "TEST",
                BtryAlt = 400,
                Charge = "_2L",
                TFT = "AM3",
                SafetyDiagramSections = new List<SafetyDiagramSection>()
                {
                    new SafetyDiagramSection()
                    {
                        LeftLimit = 4100,
                        RightLimit = 4900,
                        Range = 5000,
                        Altitude = 435,
                        IsMinTimeRange = false
                    },
                    new SafetyDiagramSection()
                    {
                        LeftLimit = 4100,
                        RightLimit = 4900,
                        Range = 9000,
                        Altitude = 410,
                    }

                }
            };

            var deflections = new Deflections(AngleOfFire.LA, 3604, 2811);
            var expectedSafetyT = new SafetyT(AngleOfFire.LA, 412, deflections, 183, 187, 14.3m, 14.5m, 20.0m);

            //Act
            var laSafetyData = safetyService.CaculatePreOccupationSafety(laSafetyInput);

            //Assert
            laSafetyData.SafetyT.Should().BeEquivalentTo(expectedSafetyT);
        }
    }
}
