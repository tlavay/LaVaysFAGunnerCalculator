using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculator.Common.Services.Extensions
{
    internal static class CommonExtensions
    {
        public static TEnum ToEnum<TEnum>(this string input)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), input);
        }
    }
}
