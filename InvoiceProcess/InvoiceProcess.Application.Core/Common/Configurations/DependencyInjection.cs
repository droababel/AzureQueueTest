using FluentValidation;
using FluentValidation.AspNetCore;
using InvoiceProcess.Application.Core.Common.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InvoiceProcess.Application.Core.Common.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
