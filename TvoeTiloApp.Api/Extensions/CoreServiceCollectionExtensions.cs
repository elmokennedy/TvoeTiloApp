using TvoeTiloApp.Contract.Repositories;
using TvoeTiloApp.Contract.Services;
using TvoeTiloApp.Core.Services;
using TvoeTiloApp.Infrastructure.DataAccess.Repositories;

namespace TvoeTiloApp.Api.Extensions
{
    public static class CoreServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
