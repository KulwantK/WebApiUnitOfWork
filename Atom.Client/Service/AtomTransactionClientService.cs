using Atom.ApiClientService.IClientService;
using Atom.Client.IService;
using Atom.Client.Models;
using AutoMapper;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Atom.Client.Service
{
    public class AtomTransactionClientService : IAtomTransactionClientService
    {
        private readonly IHttpClientService httpClientService;
        private readonly IMapper mapper;
        public AtomTransactionClientService(IHttpClientService httpClientService, IMapper mapper)
        {
            this.httpClientService= httpClientService;
            this.mapper = mapper;
        }
        public async Task<ViewModel> Balance(long id)
        {
            var httpResponse = await httpClientService.Get<RequestResponseModel>($"AtomTransaction/{id}");
            if(httpResponse.IsSuccessStatusCode)
            {
                var httpResult = JsonConvert.DeserializeObject<RequestResponseModel>(await httpResponse.Content.ReadAsStringAsync());
                return mapper.Map<ViewModel>(httpResult);
            }
            return new ViewModel() {Successful=false,Message="unable to process, please try after sometimes"};
        }
        public async Task<ViewModel> Deposit(ViewModel model)
        {
            var httpResponse = await httpClientService.Put<RequestResponseModel>("AtomTransaction/deposit", mapper.Map<RequestResponseModel>(model));
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseModel = JsonConvert.DeserializeObject<RequestResponseModel>(await httpResponse.Content.ReadAsStringAsync());
                return mapper.Map<ViewModel>(responseModel);
            }
            return new ViewModel() { Successful = false, Message = "unable to process, please try after sometimes" };
        }
        public async Task<ViewModel> Widthdraw(ViewModel model)
        {
            var httpResponse = await httpClientService.Get<RequestResponseModel>("AtomTransaction/Withdraw", mapper.Map<RequestResponseModel>(model));
            if (httpResponse.IsSuccessStatusCode)
            {
                var httpResult = JsonConvert.DeserializeObject<RequestResponseModel>(await httpResponse.Content.ReadAsStringAsync());
                return mapper.Map<ViewModel>(httpResult);
            }
            return new ViewModel() { Successful = false, Message = "unable to process, please try after sometimes" };
        }
    }
}
