namespace Segurança.Qualidade.Worker.Setup
{
    using Microsoft.Extensions.DependencyInjection;
    using Segurança.Qualidade.Application.Domain.NormasTecnicasAggregate;
    using Segurança.Qualidade.Application.Domain.SegurançaQualidadeAggregate;
    using Segurança.Qualidade.Infrastructure.Repository;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterDependencyInjectionContainer(this IServiceCollection services)
        {
            services.AddSingleton<INormasTecnicasRepository, NormasTecnicasRepository>();
            services.AddSingleton<ISegurancaQualidadeRepository, SegurancaQualidadeRepository>();

            return services;
        }
    }
}
