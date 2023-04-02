namespace Survey.WebUI.Services
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value);
        Task Put(string uri, object value);
    }
}
