using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.UnitOfWork;
using APIMarketList.Infra.Data.Repositories;
using APIMarketList.Infra.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIMarketList.Infra.CrossCutting.Services
{
    public static class DepedencyInjection
    {
        public static void RegisterDepedency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShoppingRepository, ShoppingRepository>();
            services.AddScoped<IProductShoppingRepository, ProductShoppingRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.DbContextDepdency(configuration);
        }
    }
}
