using Newtonsoft.Json;
using System.IO;

namespace GunneryCalculator.Common.Services.Helpers
{
    internal static class FileHelper
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