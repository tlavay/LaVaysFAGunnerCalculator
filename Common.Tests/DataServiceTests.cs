using GunneryCalculatorCommon.Models.Enums;
using GunneryCalculatorCommon.Services.DataLayer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Common.Tests
{
    public class DataServiceTests
    {
        private ServiceProvider serviceProvider;

        public DataServiceTests()
        {
            this.serviceProvider = TestHelper.GetServiceProvider();
        }

        [Fact]
        public void DataService_GetTechincalFiringData_WithAM3Selected_ShouldReturnAllTechincalFiringDataForAM3()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();

            //Act
            var tabularFiringTables = dataService.GetTabularFiringTables();

            //Assert
            Assert.True(tabularFiringTables.TableFox.All(x => x.TFT == TFT.AM3));
            Assert.True(tabularFiringTables.TableGolf.All(x => x.TFT == TFT.AM3));
            var firstTableFox = tabularFiringTables.TableFox.First(x => x.Range == 2000);
            var firstTableGolf = tabularFiringTables.TableGolf.First(x => x.Range == 2000);
            Assert.True(firstTableFox.Elevation > 0);
            Assert.True(firstTableGolf.Elevation > 0);
        }
    }
}
