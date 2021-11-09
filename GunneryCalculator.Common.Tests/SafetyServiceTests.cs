using FluentAssertions;
using GunneryCalculator.Common.Models;
using GunneryCalculator.Common.Models.Enums;
using GunneryCalculator.Common.Models.Safety;
using GunneryCalculator.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GunneryCalculator.Common.Tests
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
                        IsMinTimeRange = false,
                        AngleOfFire = AngleOfFire.Low
                    },
                    new SafetyDiagramSection()
                    {
                        LeftLimit = 4100,
                        RightLimit = 4900,
                        Range = 9000,
                        Altitude = 410,
                        AngleOfFire = AngleOfFire.Low
                    }
                }
            };

            var deflections = new Deflections(AngleOfFire.Low, 3604, 2811);
            var expectedSafetyT = new SafetyT(AngleOfFire.Low, 412, deflections, 183, 187, 14.3m, 14.5m, 20.0m);

            //Act
            var safety = safetyService.CaculatePreOccupationSafety(laSafetyInput);
            var laSafetyT = safety.SafetyT.Single(s => s.AngleOfFire == AngleOfFire.Low);

            //Assert
            laSafetyT.Should().BeEquivalentTo(expectedSafetyT);
        }

        [Fact]
        public void SafetyService_GetHAPreOccupationSafety_WithValidInputData_ShouldComputSafety()
        {
            //Arrange
            var safetyService = this.serviceProvider.GetService<SafetyService>();
            var laSafetyInput = new LASafetyInput()
            {
                Loaction = "TEST",
                BtryAlt = 405,
                Charge = "_2L",
                TFT = "AM3",
                SafetyDiagramSections = new List<SafetyDiagramSection>()
                {
                    new SafetyDiagramSection()
                    {
                        LeftLimit = 1700,
                        RightLimit = 2750,
                        Range = 7600,
                        Altitude = 435,
                        IsMinTimeRange = false,
                        AngleOfFire = AngleOfFire.High
                    },
                    new SafetyDiagramSection()
                    {
                        LeftLimit = 1700,
                        RightLimit = 2750,
                        Range = 10500,
                        Altitude = 465,
                        AngleOfFire = AngleOfFire.High
                    }
                }
            };

            var deflections = new Deflections(AngleOfFire.High, 3748, 2749);
            var expectedSafetyT = new SafetyT(AngleOfFire.High, 1232, deflections, 1034);

            //Act
            var safety = safetyService.CaculatePreOccupationSafety(laSafetyInput);
            var laSafetyT = safety.SafetyT.Single(s => s.AngleOfFire == AngleOfFire.High);

            //Assert
            laSafetyT.Should().BeEquivalentTo(expectedSafetyT);
        }
    }
}
