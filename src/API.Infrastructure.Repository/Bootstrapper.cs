using API.Domain.Usuarios;
using API.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure.Repository
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperRepository(this IServiceCollection services, IConfiguration configuration, string configConnectionString = "DefaultConnection")
        {
            services
               .AddDbContext<ApiDbContext>((s, options) =>
               {
                   options.UseNpgsql(configuration.GetConnectionString(configConnectionString));
               })
               .AddScoped<DbContext>(s => s.GetService<ApiDbContext>());

            //Pedir Ajuda
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
