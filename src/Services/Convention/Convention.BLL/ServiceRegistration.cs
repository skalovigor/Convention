using System.Reflection;
using System.Runtime.CompilerServices;
using Convention.BLL.Features.Convention.Services;
using Convention.BLL.Features.Identity.Services;
using Convention.BLL.Features.Services;
using Convention.BLL.Infrastructure.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
[assembly: InternalsVisibleTo("Convention.Tests")]

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
            services.AddScoped<IParticipantService, ParticipantService>();
            
            services.AddScoped<IIdentityContext, IdentityContextLoader>();

            return services;
        }
    }
}