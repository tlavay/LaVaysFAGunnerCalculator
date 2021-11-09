using FA_Manual_Gunnery_Caculator;
using GunneryCalculator.Common.Models;
using GunneryCalculator.Common.Models.TFTs;
using GunneryCalculator.Common.Services.Helpers;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GunneryCalculator.Common.Services.DataLayer
{
    public sealed class DataService
    {
        private readonly string am3FileDirectory;
        private readonly IMemoryCache memoryCache;
        private const string tabularFiringTablesKey = "TabularFiringTablesKey";
        public DataService(IMemoryCache memoryCache)
        {
            this.am3FileDirectory = $@"{AppDomain.CurrentDomain.BaseDirectory}Services\DataLayer\TempData\AM3";
            this.memoryCache = memoryCache;
        }

        public TabularFiringTables GetTabularFiringTables()
        {
            this.memoryCache.TryGetValue<TabularFiringTables>(tabularFiringTablesKey, out var tabularFiringTables);
            if (tabularFiringTables != null)
            {
                return tabularFiringTables;
            }

            //Todo: Replace this trash with actual database.
            //var tableFox = FileHelper.LoadFile<IEnumerable<TableFox>>($@"{this.am3FileDirectory}\TableFox.json");
            //var tableGolf = FileHelper.LoadFile<IEnumerable<TableGolf>>($@"{this.am3FileDirectory}\TableGolf.json");
            //tabularFiringTables = new TabularFiringTables()
            //{
            //    TableFox = tableFox,
            //    TableGolf = tableGolf
            //};

            tabularFiringTables = new TabularFiringTables()
            {
                TableFox = CreateTableFox(),
                TableGolf = CreateTableGolf()
            };

            this.memoryCache.Set(tabularFiringTablesKey, tabularFiringTables, DateTimeOffset.Now.AddMonths(1));
            return tabularFiringTables;
        }

        private IEnumerable<TableFox> CreateTableFox()
        {
            var tableFoxRows = new List<TableFox>();
            var _1Lima = Charge1Lima.TableFox.ToList();
            var _2Lima = Charge2Lima.TableFox.ToList();
            var _3Hotel = Charge3Hotel.TableFox.ToList();
            var _4Hotel = Charge4Hotel.TableFox.ToList();
            tableFoxRows.AddRange(_1Lima);
            tableFoxRows.AddRange(_2Lima);
            tableFoxRows.AddRange(_3Hotel);
            tableFoxRows.AddRange(_4Hotel);

            return tableFoxRows;
        }

        private IEnumerable<TableGolf> CreateTableGolf()
        {
            var tableGolfRow = new List<TableGolf>();

            var _1Lima = Charge1Lima.TableGolf.ToList();
            var _2Lima = Charge2Lima.TableGolf.ToList();
            var _3Hotel = Charge3Hotel.TableGolf.ToList();
            var _4Hotel = Charge4Hotel.TableGolf.ToList();
            tableGolfRow.AddRange(_1Lima);
            tableGolfRow.AddRange(_2Lima);
            tableGolfRow.AddRange(_3Hotel);
            tableGolfRow.AddRange(_4Hotel);

            return tableGolfRow;
        }
    }
}
