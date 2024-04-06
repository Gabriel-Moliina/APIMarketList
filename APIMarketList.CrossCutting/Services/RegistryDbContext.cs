using APIMarketList.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIMarketList.Infra.CrossCutting.Services
{
    public static class RegistryDbContext
    {
        public static void DbContextDepdency(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EntityContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            using var serviceScope = services.BuildServiceProvider().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<EntityContext>().Database.EnsureCreated();
        }
    }
}
