using API.Domain.Usuarios;
using API.Infrastructure.Repository.Context;
using API.Infrastructure.Repository.Repositories;
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

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
