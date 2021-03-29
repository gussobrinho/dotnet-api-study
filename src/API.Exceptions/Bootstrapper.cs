using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Exceptions
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperExceptions(this IServiceCollection services)
        {
            return services;
        }
    }
}
