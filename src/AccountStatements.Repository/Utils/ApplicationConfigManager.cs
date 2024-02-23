using Microsoft.Extensions.Configuration;

namespace AccountStatements.Repository.Utils
{
    public interface IApplicationConfigManager
    {
        string Key { get; }
    }


    public class ApplicationConfigManager : IApplicationConfigManager
    {
        private readonly IConfiguration _configuration;

        public ApplicationConfigManager(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string Key
        {
            get
            {
                return this._configuration["AppSeetings:key"];
            }
        }
    }


}
