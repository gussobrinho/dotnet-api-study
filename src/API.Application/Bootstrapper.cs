using API.Application.Abstraction.Usuarios.Querys;
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
            services
                .AddMediatR(typeof(BuscarUsuarioPorEmailQuery).Assembly);
            #endregion

            return services;
        }
    }
}
