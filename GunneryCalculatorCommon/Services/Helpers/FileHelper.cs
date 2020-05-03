using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace GunneryCalculatorCommon.Services.Helpers
{
    public static class FileHelper
    {
        private static JsonSerializerSettings jsonSerializerSettings;
        static FileHelper()
        {
            jsonSerializerSettings = new JsonSerializerSettings
            {
                FloatParseHandling = FloatParseHandling.Decimal
            };
        }
        public static TResult LoadFile<TResult>(string filePath)
        {
            return JsonConvert.DeserializeObject<TResult>(File.ReadAllText(filePath), jsonSerializerSettings);
        }
    }
}
