using API.Infrastructure.Authentication.Security;
using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure.Authentication
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrappeAutorizacaoService(this IServiceCollection services)
        {
            services
                .AddScoped<AuthenticationService>();

            services
                .AddSingleton<SigningConfigurations>()
                .AddSingleton<TokenConfigurations>();

            return services;
        }
    }
}
