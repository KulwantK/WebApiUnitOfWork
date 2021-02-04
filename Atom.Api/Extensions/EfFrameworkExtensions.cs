using Atom.Data;
using Atom.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Atom.Api.Extensions
{
    public static class EfFrameworkExtensions
    {
        public static IServiceCollection AddEntityFrameWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AtomDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
