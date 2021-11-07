using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculator.Common.Services.Helpers
{
    internal static class JsonHelper
    {
        private readonly static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
        {
            FloatParseHandling = FloatParseHandling.Decimal
        };

        public static string Serialize(object input)
        {
            return JsonConvert.SerializeObject(input, jsonSerializerSettings);
        }
    }
}
