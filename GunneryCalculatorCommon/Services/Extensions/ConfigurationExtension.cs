using GunneryCalculatorCommon.Services.DataLayer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GunneryCalculatorCommon.Services.Extensions
{
    public static class ConfigurationExtension
    {
        public static void ConfigureGunneryCaculatorCommon(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddSingleton<ServiceFactory>();
            servicesCollection.AddMemoryCache();
            servicesCollection.AddTransient<DataService>();
            servicesCollection.AddTransient<SiteService>();
        }
    }
}
