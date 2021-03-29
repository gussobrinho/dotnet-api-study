using API.Application.Usuarios.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace API.Application
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperApplication(this IServiceCollection services)
        {
            #region Commands
            services
                .AddMediatR(typeof(AdicionarUsuarioCommandHandler).Assembly);
            #endregion

            #region Querys

            #endregion

            return services;
        }
    }
}
