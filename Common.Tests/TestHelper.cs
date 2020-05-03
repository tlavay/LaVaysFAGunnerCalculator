using GunneryCalculatorCommon.Services.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Tests
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
