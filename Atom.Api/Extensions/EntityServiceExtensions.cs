using Atom.ApiService.IService;
using Atom.ApiService.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Atom.Api.Extensions
{
    public static class EntityServiceExtensions
    {
        public static IServiceCollection AddEntityService(this IServiceCollection service)
        {
            service.AddScoped<IAtomAccountService, AtomAccountService>();
            return service;
        }
    }
}
