using System.Net;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace Survey.WebUI.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(
            HttpClient httpClient
        )
        {
            _httpClient = httpClient;
        }

        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await SendRequest<T>(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = CreateRequest(HttpMethod.Post, uri, value);
            return await SendRequest<T>(request);
        }

        public async Task Put(string uri, object value)
        {
            var request = CreateRequest(HttpMethod.Put, uri, value);
            await SendRequest(request);
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, string uri, object value = null)
        {
            var request = new HttpRequestMessage(method, uri);
            if (value != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            }
            return request;
        }

        private async Task SendRequest(HttpRequestMessage request)
        {
            using var response = await _httpClient.SendAsync(request);
            await HandleErrors(response);
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage request)
        {
            // send request
            using var response = await _httpClient.SendAsync(request);

            // TODO: 401 response redirection
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // TODO: Navigate To ("??????");
                return default;
            }
            await HandleErrors(response);

            return await response.Content.ReadFromJsonAsync<T>();
        }

        private async Task HandleErrors(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
