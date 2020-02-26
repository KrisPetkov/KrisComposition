using Application;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Web;

namespace Startup
{
    public class NonUiDependencyRegistry : INonUiDependencyRegistry
    {
        public IServiceCollection RegisterAllNonUiDependencies(IServiceCollection services)
        {
            services.RegisterApplicationLayer();
            services.RegisterInfrastructureLayer();

            return services;
        }
    }
}
