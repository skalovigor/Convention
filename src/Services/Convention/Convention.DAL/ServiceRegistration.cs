using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Convention.DAL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddSqlDbServices(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddDbContext<ConventionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}