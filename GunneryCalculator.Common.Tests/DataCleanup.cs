using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GunneryCalculator.Common.Tests
{
    public class DataCleanup
    {
        [Fact]
        public void CleanUpData()
        {
            var lines = File.ReadAllLines(@"C:\Users\tylavay\Documents\TFT_RAW\Table_Fox_1-9_LA.txt");

            var cleanLines = new StringBuilder();
            foreach (var line in lines)
            {
                var cleanLineBuilder = new StringBuilder();
                var split = line.Split();
                for (int i = 0; i < split.Length; i++)
                {
                    var currentCol = split[i];
                    if (split.Length > i + 1 && split[i + 1].StartsWith("."))
                    {
                        var next = split[i + 1];
                        if (next == ".")
                        {
                            currentCol = $"{currentCol}{split[i + 1]}{split[i + 2]}";
                            i++;
                            i++;
                        }
                        else
                        {
                            currentCol = $"{currentCol}{split[i + 1]}";
                            i++;
                        }
                    }
                    else if (currentCol.EndsWith('.'))
                    {
                        currentCol = $"{currentCol}{split[i + 1]}";
                        i++;
                    }

                    if (currentCol.ToLower() != "x" && !decimal.TryParse(currentCol, out var check))
                    {
                        throw new Exception($"fucked up number. Input was {currentCol}");
                    }

                    cleanLineBuilder.Append($"{currentCol},");
                }

                var cleanLine = cleanLineBuilder.ToString();
                var finalString = cleanLine.Substring(0, cleanLine.Length - 1);
                var commaCount = finalString.Count(x => x == ',');
                if (commaCount != 8)
                {
                    throw new Exception($"Clean up failed on for range: {split[0]}. Table fox col 1-9 comma count expected to be 8 and was {commaCount}.");
                }

                cleanLines.AppendLine(finalString);
            }

            var blah = cleanLines.ToString();
        }
    }
}
