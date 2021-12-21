using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Segurança.Qualidade.Worker.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segurança.Qualidade.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddCustomMediatR();
                    services.RegisterDependencyInjectionContainer();
                    services.AddHostedService<Worker>();
                });
    }
}
