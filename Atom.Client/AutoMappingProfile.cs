using Atom.Client.Models;
using AutoMapper;

namespace Atom.Client
{
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<ViewModel, RequestResponseModel>().ReverseMap();
        }
    }
}
