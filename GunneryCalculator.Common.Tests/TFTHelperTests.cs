﻿using FluentAssertions;
using GunneryCalculator.Common.Models.Enums;
using GunneryCalculator.Common.Models.TFTs;
using GunneryCalculator.Common.Services.DataLayer;
using GunneryCalculator.Common.Services.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GunneryCalculator.Common.Tests
{
    public class TFTHelperTests
    {
        private ServiceProvider serviceProvider;

        public TFTHelperTests()
        {
            this.serviceProvider = TestHelper.GetServiceProvider();
        }

        [Fact]
        public void TFTHelper_TableGolf_WithWholeRange_ShouldReturnRowAtRange()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var am3TableGolf = dataService.GetTabularFiringTables();
            var expectedTableGolf = am3TableGolf.TableGolf.First(x => x.AngleOfFire == AngleOfFire.Low && x.Charge == Charge._1L && x.Range == 2000);

            //Act
            var actualTableGolf = TFTHelper.GetTableGolfRow(am3TableGolf.TableGolf, TFT.AM3, AngleOfFire.Low, Charge._1L, 2000);

            //Assert
            actualTableGolf.Should().BeEquivalentTo(expectedTableGolf);
        }

        [Fact]
        public void TFTHelper_TableGolf_WithRange2020_ShouldInterpolatedData()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var am3TableGolf = dataService.GetTabularFiringTables();
            var expectedTableGolf = new TableGolf(
                tft: TFT.AM3,
                charge: Charge._1L,
                angleOfFire: AngleOfFire.Low,
                range: 2020,
                elevation: 111.5m,
                probErrorsR: 7,
                probErrorsD: 1,
                probErrorsHB: 1,
                probErrorsTB: 0.04m,
                probErrorsRB: 12,
                angleOfFall: 118.4m,
                cotAngleOfFall: 8.6m,
                tmlVel: 285,
                mo: 57,
                posCSF: 0.011m,
                negCSF: -0.010m);

            //Act
            var actualTableGolf = TFTHelper.GetTableGolfRow(am3TableGolf.TableGolf, TFT.AM3, AngleOfFire.Low, Charge._1L, 2020);

            //Assert
            actualTableGolf.Should().BeEquivalentTo(expectedTableGolf);
        }

        [Fact]
        public void TFTHelper_TableFox_WithWholeRange_ShouldReturnRowAtRange()
        {
            //Arrange
            var dataService = this.serviceProvider.GetService<DataService>();
            var am3Tables = dataService.GetTabularFiringTables();
            var expectedTableFox = am3Tables.TableFox.First(x => x.AngleOfFire == AngleOfFire.Low && x.Charge == Charge._1L && x.Range == 2000);

            //Act
            var actualTableFox = TFTHelper.GetTableFoxRow(am3Tables.TableFox, TFT.AM3, AngleOfFire.Low, Charge._1L, 2000);

            //Assert
            actualTableFox.Should().BeEquivalentTo(expectedTableFox);
        }



        [Fact]
        public void TFTHelper_TableFox_WithRangeOf2020_ShouldReturnInterpolatedRowAtRange()
        {
            //Arrange
            var range = 2020;
            var dataService = this.serviceProvider.GetService<DataService>();
            var am3Tables = dataService.GetTabularFiringTables();
            var expectedTableFox = new TableFox(
                tft: TFT.AM3,
                charge: Charge._1L,
                angleOfFire: AngleOfFire.Low,
                range: range,
                elevation: 111.5m,
                fsForGrazeBurstFuzeM582: 6.9m,
                dfsPer10MDecHob: 0.31m,
                drPer1MilDElev: 17,
                fork: 2,
                tof: 6.9m,
                drift: 2.1m,
                cwOf1Knot: 0.08m,
                muzzleVelocity1Dec: 11.6m,
                muzzleVelocity1Inc: -9.5m,
                rangeWind1KnotHead: 2.1m,
                rangeWind1KnotTail: -0.7m,
                airTemp1PctDec: 4.6m,
                airTemp1PctInc: -1.5m,
                airDensity1PctDec: -1.1m,
                airDensity1PctInc: 1.1m,
                projWTof1SQDec: -15,
                projWTof1SQInc: 16);

            //Act
            var actualTableFox = TFTHelper.GetTableFoxRow(am3Tables.TableFox, TFT.AM3, AngleOfFire.Low, Charge._1L, range);

            //Assert
            actualTableFox.Should().BeEquivalentTo(expectedTableFox);
        }

        //[Fact]
        //public void Test()
        //{
        //    var tableGolfs = Charge1Lima.TableGolf.Concat(Charge2Lima.TableGolf).Concat(Charge3Hotel.TableGolf).Concat(Charge4Hotel.TableGolf).Concat(Charge7Remeo.TableGolf);
        //    var tableFoxs = Charge1Lima.TableFox.Concat(Charge2Lima.TableFox).Concat(Charge3Hotel.TableFox).Concat(Charge4Hotel.TableFox).Concat(Charge7Remeo.TableFox);

        //    var jsonSearlizationSettings = new JsonSerializerSettings();
        //    jsonSearlizationSettings.FloatParseHandling = FloatParseHandling.Decimal;
        //    var tableGolfJson = JsonConvert.SerializeObject(tableGolfs, jsonSearlizationSettings);
        //    var tableFoxJson = JsonConvert.SerializeObject(tableFoxs, jsonSearlizationSettings);
        //}
    }
}
