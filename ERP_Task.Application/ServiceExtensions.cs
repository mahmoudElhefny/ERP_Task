
using System.Reflection;
using ERP_Task.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ERP_Task.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Correct MediatR v12+ registration
            services.AddMediatR(assembly);
            // FluentValidation
            services.AddValidatorsFromAssembly(assembly);

            // Add validation behavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogHistoryBehavior<,>));
            services.AddAutoMapper(assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
           
            return services;
        }
    }
}
