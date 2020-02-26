using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public interface INonUiDependencyRegistry
    {
        IServiceCollection RegisterAllNonUiDependencies(IServiceCollection services);
    }
}
