using AccountStatements.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace AccountStatements.Helpers
{
    public class HttpContentHelper : IHttpContentHelper
    {
        private readonly ILogger<HttpContentHelper> _logger;

        public HttpContentHelper(ILogger<HttpContentHelper> logger)
        {
            _logger = logger;
        }

        public StringContent GetHttpStringContent<T>(T request) where T : class
        {
            var serializeObject = JsonConvert.SerializeObject(request);

            return new StringContent(serializeObject, Encoding.UTF8, "application/json");
        }

        public async Task<T> GetResponseAsync<T>(HttpResponseMessage response)
        {
            if(response == null)
            {
                var responseError = $"HttpResponse {typeof(T).Name} was null";

                _logger.LogError(responseError);

                throw new Exception(responseError);
            }

            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _logger.LogError($"HttpResponse bad code for {typeof(T).Name} - Code: {response.StatusCode} - Content: {content}");

                throw new Exception(content);
            }

            return string.IsNullOrEmpty(content) ? default(T) : JsonConvert.DeserializeObject<T>(content);
        }
    }
}
