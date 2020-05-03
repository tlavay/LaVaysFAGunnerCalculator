using GunneryCalculatorCommon.Models.TFTs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models
{
    public sealed class TabularFiringTables
    {
        public IEnumerable<TableFox> TableFox { get; set; }
        public IEnumerable<TableGolf> TableGolf { get; set; }
    }
}
