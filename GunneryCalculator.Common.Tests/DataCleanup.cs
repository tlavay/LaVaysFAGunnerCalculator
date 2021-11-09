//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace GunneryCalculator.Common.Tests
//{
//    public class DataCleanup
//    {
//        [Fact]
//        public void CleanUpData()
//        {
//            var col1_9s = File.ReadAllLines(@"C:\Users\tylavay\Documents\TFT_RAW\Table_Fox_1-9_LA.txt");
//            var col10_18s = File.ReadAllLines(@"C:\Users\tylavay\Documents\TFT_RAW\Table_Fox_10-18_LA.txt");

//            var cleanLines = new StringBuilder();
//            var col1Enumerator = col1_9s.GetEnumerator();
//            var col10Enumerator = col10_18s.GetEnumerator();
//            while (col1Enumerator.MoveNext())
//            {
//                col10Enumerator.MoveNext();
//                var currentCol1 = col1Enumerator.Current.ToString();
//                var currentCol10 = col10Enumerator.Current.ToString();

//                var col1Split = currentCol1.Split();
//                var col10Split = currentCol10.Split();
//                var col1Range = col1Split[0];
//                var col10Range = col10Split[0];
//                if (col1Range != col10Range)
//                {
//                    throw new Exception($"Fuck, these ranges didn't equal. first range: {col1Range}, second range: {col10Range}");
//                }

//                var col1_9Final = GetCurrentCleanRow(col1Split, false);
//                var col10_18Final = GetCurrentCleanRow(col10Split, true);

//                var finalString = $"{col1_9Final},{col10_18Final}";
//                cleanLines.AppendLine(finalString);
//            }

//            var blah = cleanLines.ToString();
//        }

//        private string GetCurrentCleanRow(string[] splitValues, bool isCol10)
//        {
//            var cleanLineBuilder = new StringBuilder();
//            //so we skip the range on the second go around
//            var startingIterator = isCol10 ? 1 : 0;
//            for (int i = startingIterator; i < splitValues.Length; i++)
//            {
//                var currentValue = splitValues[i];
//                if (splitValues.Length > i + 1 && splitValues[i + 1].StartsWith("."))
//                {
//                    var next = splitValues[i + 1];
//                    if (next == ".")
//                    {
//                        currentValue = $"{currentValue}{splitValues[i + 1]}{splitValues[i + 2]}";
//                        i++;
//                        i++;
//                    }
//                    else
//                    {
//                        currentValue = $"{currentValue}{splitValues[i + 1]}";
//                        i++;
//                    }
//                }
//                else if (currentValue.EndsWith('.'))
//                {
//                    currentValue = $"{currentValue}{splitValues[i + 1]}";
//                    i++;
//                }

//                if (currentValue.ToLower() != "x" && !decimal.TryParse(currentValue, out var check))
//                {
//                    throw new Exception($"fucked up number. Input was {currentValue}");
//                }

//                cleanLineBuilder.Append($"{currentValue},");
//            }

//            var cleanLine = cleanLineBuilder.ToString();
//            var finalString = cleanLine.Substring(0, cleanLine.Length - 1);
//            var commaCount = finalString.Count(x => x == ',');
//            if (!isCol10 && commaCount != 8)
//            {
//                throw new Exception($"Clean up failed on for range: {splitValues[0]}. Table fox col 1-9 comma count expected to be 8 and was {commaCount}.");
//            }
//            else if (isCol10 && commaCount != 9)
//            {
//                throw new Exception($"Clean up failed on for range: {splitValues[0]}. Table fox col 10-18 comma count expected to be 9 and was {commaCount}.");
//            }

//            //remove last comma
//            var finalValue = cleanLineBuilder.ToString();
//            return finalValue.Substring(0, finalValue.Length - 1);
//        }
//    }
//}
