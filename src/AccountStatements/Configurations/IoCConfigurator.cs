using AccountStatements.Settings;
using Microsoft.Extensions.Options;

namespace AccountStatements.Configurations
{
    public static class IoCConfigurator
    {
        public static IServiceCollection HttpClientFactoryConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            var AccountStatementsServiceSettings = GetSettings<AccountStatementsServiceSettings>(services, configuration, "AccountStatementsAPISettings");

            services.AddHttpClient("AccountStatementsClient", client =>
            {
                client.BaseAddress = new Uri(AccountStatementsServiceSettings.BaseAddress);
            });

            return services;
        }

        private static T GetSettings<T>(IServiceCollection service, IConfiguration configuration, string sectionSetting) 
            where T : class, new()
        {
            var section = configuration.GetSection(sectionSetting);
            var setting=new T();

            new ConfigureFromConfigurationOptions<T>(section)
                .Configure(setting);

            service.AddSingleton(setting);

            return setting;
        }
    }
}
