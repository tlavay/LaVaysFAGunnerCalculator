using GunneryCalculatorCommon.Models;
using GunneryCalculatorCommon.Models.Enums;
using GunneryCalculatorCommon.Models.TFTs;
using GunneryCalculatorCommon.Services.Helpers;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GunneryCalculatorCommon.Services.DataLayer
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
            var tableFox = FileHelper.LoadFile<IEnumerable<TableFox>>($@"{this.am3FileDirectory}\TableFox.json");
            var tableGolf = FileHelper.LoadFile<IEnumerable<TableGolf>>($@"{this.am3FileDirectory}\TableGolf.json");
            tabularFiringTables = new TabularFiringTables()
            {
                TableFox = tableFox,
                TableGolf = tableGolf
            };

            this.memoryCache.Set(tabularFiringTablesKey, tabularFiringTables, DateTimeOffset.Now.AddMonths(1));
            return tabularFiringTables;
        }
    }
}
