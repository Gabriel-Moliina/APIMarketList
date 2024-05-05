using APIMarketList.Application.Application;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.Infra.Data.Repositories;
using APIMarketList.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIMarketList.Infra.CrossCutting.Services
{
    public static class DepedencyInjection
    {
        public static void RegistryDepedency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<IShoppingApplication, ShoppingApplication>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShoppingRepository, ShoppingRepository>();
            services.AddScoped<IProductShoppingRepository, ProductShoppingRepository>();

            services.DbContextDepdency(configuration);
        }
    }
}
