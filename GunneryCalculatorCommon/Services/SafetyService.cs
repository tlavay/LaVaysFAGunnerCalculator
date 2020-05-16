using GunneryCalculatorCommon.Models;
using GunneryCalculatorCommon.Models.Enums;
using GunneryCalculatorCommon.Services.Builders;
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

        public void CaculatePreOccupationSafety()
        {

        }

        public LASafety CaculatePreOccupationLASafety(LASafetyInput lASafetyInput)
        {
            var tftParse = (TFT)Enum.Parse(typeof(TFT), lASafetyInput.TFT);
            var chargeParse = (Charge)Enum.Parse(typeof(Charge), lASafetyInput.Charge);
            var tabularFiringTables = this.dataService.GetTabularFiringTables();
            var laSafetyRows = LASafetyRowBuilder.Build(
                lASafetyInput.SafetyDiagramSections,
                tftParse,
                chargeParse,
                tabularFiringTables,
                lASafetyInput.BtryAlt);
            var laSafetyDiagrams = LASafetyDiagramBuilder.Build(lASafetyInput.SafetyDiagramSections, laSafetyRows.LASafetyRowStandardConditions);
            var safetyTs = LASafetyTBuilder.Build(laSafetyRows, laSafetyDiagrams);

            return new LASafety(
                lASafetyInput.Loaction, 
                lASafetyInput.BtryAlt,
                lASafetyInput.Charge,
                lASafetyInput.TFT,
                laSafetyDiagrams, 
                laSafetyRows,
                safetyTs);
        }
    }
}
