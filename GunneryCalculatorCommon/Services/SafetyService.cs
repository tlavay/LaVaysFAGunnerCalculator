using GunneryCalculatorCommon.Models;
using GunneryCalculatorCommon.Models.Enums;
using GunneryCalculatorCommon.Models.Safety;
using GunneryCalculatorCommon.Services.DataLayer;
using GunneryCalculatorCommon.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace GunneryCalculatorCommon.Services
{
    public sealed class SafetyService
    {
        private readonly DataService dataService;
        public SafetyService(DataService dataService)
        {
            this.dataService = dataService;
        }

        public LASafety CaculatePreOccupationSafety(LASafetyInput lASafetyInput)
        {
            var tftParse = (TFT)Enum.Parse(typeof(TFT), lASafetyInput.TFT);
            var chargeParse = (Charge)Enum.Parse(typeof(Charge), lASafetyInput.Charge);
            var tabularFiringTables = this.dataService.GetTabularFiringTables();
            var safetyRows = SafetyHelper.BuildSafetyRows(
                lASafetyInput.SafetyDiagramSections,
                tftParse,
                chargeParse,
                tabularFiringTables,
                lASafetyInput.BtryAlt);
            var laSafetyDiagrams = SafetyHelper.BuildSafetyDiagram(
                lASafetyInput.SafetyDiagramSections, 
                safetyRows.LASafetyRowStandardConditions,
                safetyRows.HASafetyRowDataStandardCondition);
            var safetyTs = SafetyHelper.BuildSafetyTs(safetyRows, laSafetyDiagrams);

            return new LASafety(
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
