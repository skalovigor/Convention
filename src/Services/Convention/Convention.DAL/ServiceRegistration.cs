using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Convention.DAL
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddSqlDbServices(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddDbContext<ConventionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            return services;
        }
    }
}