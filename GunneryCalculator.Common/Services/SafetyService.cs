using GunneryCalculator.Common.Models;
using GunneryCalculator.Common.Models.Enums;
using GunneryCalculator.Common.Models.Safety;
using GunneryCalculator.Common.Services.DataLayer;
using GunneryCalculator.Common.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace GunneryCalculator.Common.Services
{
    public sealed class SafetyService
    {
        private readonly DataService dataService;
        public SafetyService(DataService dataService)
        {
            this.dataService = dataService;
        }

        public Safety CaculatePreOccupationSafety(LASafetyInput lASafetyInput)
        {
            //1. Get TFT Data
            var tftParse = (TFT)Enum.Parse(typeof(TFT), lASafetyInput.TFT);
            var chargeParse = (Charge)Enum.Parse(typeof(Charge), lASafetyInput.Charge);
            var tabularFiringTables = this.dataService.GetTabularFiringTables();

            //2. Build Safety Rows
            var safetyRows = SafetyHelper.BuildSafetyRows(
                lASafetyInput.SafetyDiagramSections,
                tftParse,
                chargeParse,
                tabularFiringTables,
                lASafetyInput.BtryAlt);

            //3. Build Safety Diagrams
            var laSafetyDiagrams = SafetyHelper.BuildSafetyDiagram(
                lASafetyInput.SafetyDiagramSections, 
                safetyRows.LASafetyRowStandardConditions,
                safetyRows.HASafetyRowDataStandardCondition);

            //4. Build Safety T's
            var safetyTs = SafetyHelper.BuildSafetyTs(safetyRows, laSafetyDiagrams);

            //5. Return Safety Data
            return new Safety(
                lASafetyInput.Loaction, 
                lASafetyInput.BtryAlt,
                lASafetyInput.Charge,
                lASafetyInput.TFT,
                laSafetyDiagrams, 
                safetyRows,
                safetyTs);
        }
    }
}
