using API.Application;
using API.Application.Abstraction;
using API.Domain;
using API.Exceptions;
using API.Infrastructure.Authentication;
using API.Infrastructure.Repository;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Reflection;

namespace API.IoC
{
    public static class Bootstrapper
    {
        private static Assembly[] assemblies = new[]
        {
            Assembly.GetEntryAssembly(),
            typeof(Domain.Bootstrapper).Assembly,
            typeof(Application.Bootstrapper).Assembly,
            typeof(Application.Abstraction.Bootstrapper).Assembly,
            typeof(Infrastructure.Repository.Bootstrapper).Assembly,
            typeof(Exceptions.Bootstrapper).Assembly,
            typeof(Infrastructure.Authentication.Bootstrapper).Assembly,
        };

        public static IServiceCollection AddBootstrapperIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddBootstrapperDomain()
                .AddBootstrapperApplication()
                .AddBootstrapperAbstraction()
                .AddBootstrapperExceptions()
                .AddBootstrappeAutorizacaoService()
                .AddBootstrapperRepository(configuration);

            services.AddScoped<HttpClient>(s => new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate, arg3, arg4) => true
            }));

            services.AddValidations();

            services.AddAutoMapper(assemblies, ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            AssemblyScanner.FindValidatorsInAssemblies(assemblies).ForEach(f => 
            {
                services.AddTransient(f.InterfaceType, f.ValidatorType);
                services.AddTransient(f.ValidatorType, f.ValidatorType);
            });

            return services;
        }
    }
}
