using InvoiceProcess.Application.Core.Common.Configurations;
using InvoiceProcess.Infrasctructure.Core.Configurations;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(InvoiceProcess.BackgroundJobs.InvoiceProcessor.Startup))]

namespace InvoiceProcess.BackgroundJobs.InvoiceProcessor
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            builder.Services
            .AddApplicationCore()
            .AddPersistence(configuration)
            .AddInfrastructure()
            .AddHttpClient(configuration);
        }
    }
}
