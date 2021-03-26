using Microsoft.Extensions.DependencyInjection;

namespace API.Application.Abstraction
{

    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperAbstraction(this IServiceCollection services)
        {
            return services;
        }
    }
}
