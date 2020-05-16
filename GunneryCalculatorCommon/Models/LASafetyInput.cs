﻿using System;
using System.Collections.Generic;

namespace GunneryCalculatorCommon.Models
{
    public sealed class LASafetyInput
    {
        public string Loaction { get; set; }
        public int BtryAlt { get; set; }
        public string Charge { get; set; }
        public string TFT { get; set; }
        public IEnumerable<SafetyDiagramSection> SafetyDiagramSections { get; set; }
    }
}
