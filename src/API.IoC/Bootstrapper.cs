﻿using System.Reflection;
using API.Domain;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using API.Application;
using API.Application.Abstraction;
using MediatR;

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
        };

        public static IServiceCollection AddBootstrapperIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddBootstrapperDomain()
                .AddBootstrapperApplication()
                .AddBootstrapperAbstraction();

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
