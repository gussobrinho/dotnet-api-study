using API.Application.Somas.Querys;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using API.Application.Abstraction.Usuarios.Commands;
using API.Application.Usuarios.Commands;

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
            services
                .AddMediatR(typeof(SomarNumerosQueryHandler).Assembly);
            #endregion

            return services;
        }
    }
}
