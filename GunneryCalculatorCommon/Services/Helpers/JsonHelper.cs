using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunneryCalculatorCommon.Services.Helpers
{
    internal static class JsonHelper
    {
        private readonly static JsonSerializerSettings jsonSerializerSettings;
        static JsonHelper()
        {
            jsonSerializerSettings = new JsonSerializerSettings()
            {
                FloatParseHandling = FloatParseHandling.Decimal
            };
        }

        private static string Serialize(object input)
        {
            return JsonConvert.SerializeObject(input, jsonSerializerSettings);
        }
    }
}
