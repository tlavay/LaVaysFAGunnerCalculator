using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Models
{
    public sealed class Deflections
    {
        public int Left { get; }
        public int Right { get; }
        public Deflections(int left, int right)
        {
            this.Left = left;
            this.Right = right;
        }
    }
}
