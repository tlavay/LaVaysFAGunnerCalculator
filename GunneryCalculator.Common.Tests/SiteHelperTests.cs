using GunneryCalculator.Common.Exceptions;
using GunneryCalculator.Common.Models.Enums;
using GunneryCalculator.Common.Services.DataLayer;
using GunneryCalculator.Common.Services.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GunneryCalculator.Common.Tests
{
    //All of these tests need to be validated by a human
    //2021-07-07
    public class SiteHelperTests
    {
        private ServiceProvider serviceProvider;

        public SiteHelperTests()
        {
            this.serviceProvider = TestHelper.GetServiceProvider();
        }

        [Fact]
        public void FindSite_LA_WithValidInputs_ShouldReturn0()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var tabularFiringTables = dataService.GetTabularFiringTables();
            var brtyAlt = 0;
            var tgtAlt = 0;
            var range = 2000;
            var charge = Charge._1L;
            var angleOfFire = AngleOfFire.Low;
            var tft = TFT.AM3;
            var expectedSite = 0;

            //Act
            var actualSite = SiteHelper.FindSite(tabularFiringTables, brtyAlt, tgtAlt, range, charge, angleOfFire, tft);

            //Assert
            Assert.Equal(expectedSite, actualSite);
        }

        [Fact]
        public void FindSite_LA_WithValidInputs_ShouldReturn5()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var tabularFiringTables = dataService.GetTabularFiringTables();
            var brtyAlt = 0;
            var tgtAlt = 10;
            var range = 2000;
            var charge = Charge._1L;
            var angleOfFire = AngleOfFire.Low;
            var tft = TFT.AM3;
            var expectedSite = 5;

            //Act
            var actualSite = SiteHelper.FindSite(tabularFiringTables, brtyAlt, tgtAlt, range, charge, angleOfFire, tft);

            //Assert
            Assert.Equal(expectedSite, actualSite);
        }

        [Fact]
        public void FindSite_LA_WithValidInputs_ShouldReturnNeg5()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var tabularFiringTables = dataService.GetTabularFiringTables();
            var brtyAlt = 10;
            var tgtAlt = 0;
            var range = 2000;
            var charge = Charge._1L;
            var angleOfFire = AngleOfFire.Low;
            var tft = TFT.AM3;
            var expectedSite = -5;

            //Act
            var actualSite = SiteHelper.FindSite(tabularFiringTables, brtyAlt, tgtAlt, range, charge, angleOfFire, tft);

            //Assert
            Assert.Equal(expectedSite, actualSite);
        }

        [Fact]
        public void FindSite_HA_WithValidInputs_ShouldReturn0()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var tabularFiringTables = dataService.GetTabularFiringTables();
            var brtyAlt = 0;
            var tgtAlt = 0;
            var range = 2000;
            var charge = Charge._1L;
            var angleOfFire = AngleOfFire.High;
            var tft = TFT.AM3;
            var expectedSite = 0;

            //Act
            var actualSite = SiteHelper.FindSite(tabularFiringTables, brtyAlt, tgtAlt, range, charge, angleOfFire, tft);

            //Assert
            Assert.Equal(expectedSite, actualSite);
        }

        [Fact]
        public void FindSite_HA_WithSupportedMinRange_ShouldReturn0()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var tabularFiringTables = dataService.GetTabularFiringTables();
            var brtyAlt = 0;
            var tgtAlt = 10;
            var range = 4500;
            var charge = Charge._1L;
            var angleOfFire = AngleOfFire.High;
            var tft = TFT.AM3;
            var expectedSite = 0;

            //Act
            var actualSite = SiteHelper.FindSite(tabularFiringTables, brtyAlt, tgtAlt, range, charge, angleOfFire, tft);

            //Assert
            Assert.Equal(expectedSite, actualSite);
        }

        [Fact]
        public void FindSite_HA_WithSupportedMinRange_ShouldReturn1()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var tabularFiringTables = dataService.GetTabularFiringTables();
            var brtyAlt = 0;
            var tgtAlt = 33;
            var range = 4500;
            var charge = Charge._1L;
            var angleOfFire = AngleOfFire.High;
            var tft = TFT.AM3;
            var expectedSite = -1;

            //Act
            var actualSite = SiteHelper.FindSite(tabularFiringTables, brtyAlt, tgtAlt, range, charge, angleOfFire, tft);

            //Assert
            Assert.Equal(expectedSite, actualSite);
        }

        [Fact]
        public void FindSite_HA_WithLongerThanMaxRange_ShouldReturn1()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var tabularFiringTables = dataService.GetTabularFiringTables();
            var brtyAlt = 0;
            var tgtAlt = 33;
            var range = 7600;
            var charge = Charge._1L;
            var angleOfFire = AngleOfFire.High;
            var tft = TFT.AM3;
            var expectedSite = -6;

            //Act
            var actualSite = SiteHelper.FindSite(tabularFiringTables, brtyAlt, tgtAlt, range, charge, angleOfFire, tft);

            //Assert
            Assert.Equal(expectedSite, actualSite);
        }

        [Fact]
        public void FindSite_HA_WithUnsupportedMinRange_ShouldThrowSiteException()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var tabularFiringTables = dataService.GetTabularFiringTables();
            var brtyAlt = 10;
            var tgtAlt = 0;
            var range = 2000;
            var charge = Charge._1L;
            var angleOfFire = AngleOfFire.High;
            var tft = TFT.AM3;
            var expectedErrorMessageContents = $"HA Site can not be calculated for range: {range}";

            //Act
            try
            {
                SiteHelper.FindSite(tabularFiringTables, brtyAlt, tgtAlt, range, charge, angleOfFire, tft);
                //Test fails if it gets here
                Assert.True(false);
            }
            catch (SiteException siteException)
            {
                //Assert
                Assert.StartsWith(expectedErrorMessageContents, siteException.Message);
            }
        }
    }
}
