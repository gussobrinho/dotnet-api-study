using API.Domain.Usuarios;
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
                .AddScoped<UsuarioService>();

            //services.AddScoped<Interface, Service>();

            return services;
        }
    }
}
