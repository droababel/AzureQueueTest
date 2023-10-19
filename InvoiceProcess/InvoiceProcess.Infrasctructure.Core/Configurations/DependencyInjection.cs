using InvoiceProcess.Domain.Core.Factories;
using InvoiceProcess.Domain.Core.Repositories;
using InvoiceProcess.Domain.Core.Services;
using InvoiceProcess.Infrasctructure.Core.Data;
using InvoiceProcess.Infrasctructure.Core.Factories;
using InvoiceProcess.Infrasctructure.Core.Repositories;
using InvoiceProcess.Infrasctructure.Core.Services.Azure;
using InvoiceProcess.Infrasctructure.Core.Services.FileHandler;
using InvoiceProcess.Infrasctructure.Core.Services.RequestHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceProcess.Infrasctructure.Core.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IQueuesService, AzureStorageQueueService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<EntityFactory, EntityFactory>();
            services.AddScoped<IInvoiceFactory, EntityFactory>();

            services.AddScoped<ExcelHandler, ExcelHandler>();

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvoiceProcessDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "InvoicesDb", b => b.EnableNullChecks(false));
            });

            return services;
        }

        public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<HttpRequestService>((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri("http://localhost:7053/api/");
            });

            return services;
        }

    }
}
