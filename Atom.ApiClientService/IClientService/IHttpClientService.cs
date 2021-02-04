using System.Net.Http;
using System.Threading.Tasks;

namespace Atom.ApiClientService.IClientService
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> Get<TType>(string url,TType entityDto);
        Task<HttpResponseMessage> Get<TType>(string url);
        Task<HttpResponseMessage> Put<TType>(string url, TType entityDto);
    }
}
