namespace AccountStatements.Interfaces
{
    public interface IHttpContentHelper
    {
        StringContent GetHttpStringContent<T>(T request) where T : class;
        Task<T> GetResponseAsync<T>(HttpResponseMessage response);
    }
}
