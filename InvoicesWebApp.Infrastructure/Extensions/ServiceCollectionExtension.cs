using InvoicesWebApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoicesWebApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvoicesWebAppDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("LocalDBDevelopmentConnectionString")));
        }
    }
}
