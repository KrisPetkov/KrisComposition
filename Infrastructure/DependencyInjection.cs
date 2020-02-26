using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection services)
        {
            return services.AddScoped<IRepository, Repository>();
        }
    }
}
