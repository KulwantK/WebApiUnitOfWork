using Atom.ApiClientService.IClientService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Atom.ApiClientService.ClientService
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient httpClient;
        private string baseUrl = string.Empty;
        public HttpClientService(HttpClient httpClient,IConfiguration configuration)
        {
            this.httpClient = httpClient;
            baseUrl = configuration.GetSection("baseUrl").Value;
        }
        public async Task<HttpResponseMessage> Get<TType>(string url)
        {
            var uri = new Uri($"{baseUrl}/{url}");
            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                var httpResponse = await httpClient.SendAsync(request);
                return httpResponse;
            }
        }
        public async Task<HttpResponseMessage> Get<TType>(string url,TType entityDto)
        {
            var uri = new Uri($"{baseUrl}/{url}");
            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(entityDto), Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.SendAsync(request);
                return httpResponse;
            }
        }
        public async Task<HttpResponseMessage> Put<TType>(string url, TType entityDto)
        {
            var uri = new Uri($"{baseUrl}/{url}");
            using (var request = new HttpRequestMessage(method: HttpMethod.Put, requestUri: uri))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(entityDto), Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.SendAsync(request);
                return httpResponse;
            }
        }
    }
}
