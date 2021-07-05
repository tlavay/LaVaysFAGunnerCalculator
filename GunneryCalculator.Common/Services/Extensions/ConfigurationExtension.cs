using GunneryCalculator.Common.Services.DataLayer;
using Microsoft.Extensions.DependencyInjection;

namespace GunneryCalculator.Common.Services.Extensions
{
    public static class ConfigurationExtension
    {
        public static void ConfigureGunneryCaculatorCommon(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddSingleton<ServiceFactory>();
            servicesCollection.AddMemoryCache();
            servicesCollection.AddTransient<DataService>();
            servicesCollection.AddTransient<SafetyService>();
        }
    }
}
