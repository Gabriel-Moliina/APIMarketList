using APIMarketList.Application.Application;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.Domain.Mappers;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories;
using APIMarketList.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIMarketList.Infra.CrossCutting.Services
{
    public static class IoC
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .RegistryDepedency(configuration)
                .DbContextDepdency(configuration)
                .AddMappers();
        }
        public static IServiceCollection RegistryDepedency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>()
                .AddScoped<IShoppingListService, ShoppingListService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IUserApplication, UserApplication>()
                .AddScoped<IProductApplication, ProductApplication>()
                .AddScoped<IShoppingListApplication, ShoppingListApplication>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IShoppingListRepository, ShoppingListRepository>();

            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProduct));
            return services;
        }

        public static IServiceCollection DbContextDepdency(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EntityContext>(options =>
                options.UseSqlServer(connectionString));

            using var serviceScope = services.BuildServiceProvider().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<EntityContext>().Database.EnsureCreated();

            return services;
        }
    }
}
