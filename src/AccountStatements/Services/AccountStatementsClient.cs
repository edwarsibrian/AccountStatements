using AccountStatements.Services.Interfaces;

namespace AccountStatements.Services
{
    public class AccountStatementsClient : IAccountStatementsClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<AccountStatementsClient> _logger;
        
        public AccountStatementsClient(
            ILogger<AccountStatementsClient> logger,
            IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("AccountStatementsClient");
            _logger = logger;
        }
    }
}
