using AccountStatements.Interfaces;
using AccountStatements.Repository.Entities;

namespace AccountStatements.Services
{
    public class AccountStatementsClient : IAccountStatementsClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<AccountStatementsClient> _logger;
        private readonly IHttpContentHelper _contentHelper;
        
        public AccountStatementsClient(
            ILogger<AccountStatementsClient> logger,
            IHttpClientFactory httpClientFactory,
            IHttpContentHelper httpContentHelper)
        {
            _client = httpClientFactory.CreateClient("AccountStatementsClient");
            _logger = logger;
            _contentHelper = httpContentHelper;
        }

        public async Task<List<CreditCard>> GetAllCreditCards()
        {
            var response = await _client.GetAsync("api/CreditCard");

            return await _contentHelper.GetResponseAsync<List<CreditCard>>(response);
        }
    }
}
