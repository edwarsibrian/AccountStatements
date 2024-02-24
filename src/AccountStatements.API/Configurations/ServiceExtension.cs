using AccountStatements.API.Configurations.Handlers;
using AccountStatements.Repository.Interfaces;
using AccountStatements.Repository.Services;
using AccountStatements.Repository.Utils;

namespace AccountStatements.API.Configurations
{
    public static class ServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            //Handler
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            //Scope
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ICreditCardService, CreditCardService>();

            //Singlenton
            services.AddSingleton<IApplicationConfigManager, ApplicationConfigManager>();
            services.AddSingleton<IEncryptDecryptString, EncryptDecryptString>();
        }
    }
}
