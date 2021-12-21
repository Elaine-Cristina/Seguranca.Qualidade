namespace Segurança.Qualidade.Worker.Setup
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
                AppDomain.CurrentDomain.Load("Segurança.Qualidade.Infrastructure"),
                AppDomain.CurrentDomain.Load("Segurança.Qualidade.Application"),
                AppDomain.CurrentDomain.Load("Segurança.Qualidade.Worker")
            };

            services.AddMediatR(assemblies);
            return services;
        }
    }
}
