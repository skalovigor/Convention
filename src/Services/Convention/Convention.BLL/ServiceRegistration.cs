using System.Reflection;
using Convention.BLL.Features.Convention.Services;
using Convention.BLL.Features.Identity.Services;
using Convention.BLL.Infrastructure.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Convention.BLL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            
            //TODO: all services should be injected automatically
            services.AddScoped<IConventionService, ConventionService>();
            
            services.AddScoped<IIdentityContext, IdentityContextLoader>();

            return services;
        }
    }
}