using GunneryCalculator.Common.Services.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.IO;

namespace GunneryCalculator.Common.Tests
{
    public class TestHelper
    {
        public static ServiceProvider GetServiceProvider()
        {
            //var configuration = new ConfigurationBuilder().AddUserSecrets<TestHelper>().Build();
            var services = new ServiceCollection();
            //services.AddSingleton<IConfiguration>(configuration);
            services.ConfigureGunneryCaculatorCommon();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public static TResult LoadFile<TResult>(string filePath)
        {
            return JsonConvert.DeserializeObject<TResult>(File.ReadAllText(filePath));
        }
    }
}
