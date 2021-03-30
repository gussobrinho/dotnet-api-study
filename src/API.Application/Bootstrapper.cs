using API.Application.Logins.Commands;
using API.Application.Usuarios.Commands;
using API.Application.Usuarios.Querys;
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
                .AddMediatR(typeof(AdicionarUsuarioCommandHandler).Assembly)
                .AddMediatR(typeof(LoginCommandHandler).Assembly);
            #endregion

            #region Querys
            services
                .AddMediatR(typeof(BuscarUsuarioPorEmailQueryHandler).Assembly);
            #endregion

            return services;
        }
    }
}
