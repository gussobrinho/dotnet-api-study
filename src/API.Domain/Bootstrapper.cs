using API.Domain.Somas;
using Microsoft.Extensions.DependencyInjection;

namespace API.Domain
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperDomain(this IServiceCollection services)
        {
            /// EXEMPLO ///
            //services.AddScoped<service>();
            services
                .AddScoped<SomaService>();

            //services.AddScoped<Interface, Service>();
            
            return services;
        }
    }
}
