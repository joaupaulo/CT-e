using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace CTeApi.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMediatrAssembly(this IServiceCollection services)
        {
            var applicationAssembly = AppDomain.CurrentDomain.Load("CTe.Application");

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        }
    }
}
