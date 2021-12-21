namespace Segurança.Qualidade.WebApi.Setup
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    [ExcludeFromCodeCoverage]
    public static class MediatrSetup
    {
        public static IServiceCollection AddCustomMediatR(this IServiceCollection services)
        {
            var assemblies = new Assembly[] {
                AppDomain.CurrentDomain.Load("Seguranca.Qualidade.Application"),
                AppDomain.CurrentDomain.Load("Seguranca.Qualidade.Infrastructure"),
                AppDomain.CurrentDomain.Load("Seguranca.Qualidade.WebApi")
            };

            services.AddMediatR(assemblies);
            return services;
        }
    }
}
