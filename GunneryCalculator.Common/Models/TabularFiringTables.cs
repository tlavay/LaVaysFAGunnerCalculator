using GunneryCalculator.Common.Models.TFTs;
using System.Collections.Generic;

namespace GunneryCalculator.Common.Models
{
    public sealed class TabularFiringTables
    {
        public IEnumerable<TableFox> TableFox { get; set; }
        public IEnumerable<TableGolf> TableGolf { get; set; }
    }
}
