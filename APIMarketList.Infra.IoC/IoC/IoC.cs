using APIMarketList.Application.Application;
using APIMarketList.Application.Interface;
using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.DTO.ShoppingListItem;
using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Interface.Notification;
using APIMarketList.Domain.Interface.Repositories;
using APIMarketList.Domain.Interface.Services;
using APIMarketList.Domain.Mappers;
using APIMarketList.Domain.Notification;
using APIMarketList.Domain.Services;
using APIMarketList.Domain.Validator.ShoppingList;
using APIMarketList.Domain.Validator.ShoppingListItem;
using APIMarketList.Domain.Validator.User;
using APIMarketList.Infra.CrossCutting.Cryptography;
using APIMarketList.Infra.Data.Context;
using APIMarketList.Infra.Data.Repositories;
using APIMarketList.Services.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace APIMarketList.Infra.IoC.IoC
{

    public static class IoC
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .DbContextDepdency(configuration)
                .RegistryDepedencyServices(configuration)
                .RegistryDepedencyApplications(configuration)
                .RegistryDepedencyRepositories(configuration)
                .ConfigureAuthentication(configuration)
                .AddMappers()
                .AddValidators()
                .ConfigureServices(configuration);
        }
        public static IServiceCollection RegistryDepedencyServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>()
                .AddScoped<IShoppingListService, ShoppingListService>()
                .AddScoped<IMemberService, MemberService>()
                .AddScoped<IShoppingListItemService, ShoppingListItemService>();

            return services;
        }
        
        public static IServiceCollection RegistryDepedencyApplications(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserApplication, UserApplication>()
                .AddScoped<IShoppingListApplication, ShoppingListApplication>()
                .AddScoped<IMemberApplication, MemberApplication>()
                .AddScoped<IShoppingListItemApplication, ShoppingListItemApplication>();

            return services;
        }
        
        public static IServiceCollection RegistryDepedencyRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IShoppingListRepository, ShoppingListRepository>()
                .AddScoped<IMemberRepository, MemberRepository>()
                .AddScoped<IShoppingListItemRepository, ShoppingListItemRepository>();

            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperUser));
            return services;
        }
        
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserSaveDTO>, UserSaveValidator>();
            services.AddScoped<IValidator<ShoppingListSaveDTO>, ShoppingListSaveValidator>();
            services.AddScoped<IValidator<InviteMemberDTO>, InviteMemberValidator>();
            services.AddScoped<IValidator<ShoppingListItemSaveDTO>, ShoppingListItemSaveValidator>();
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

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfigureOptions<EncryptKey>, EncryptKeyConfigurator>();
            services.AddScoped<INotification, NotificationContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }

        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITokenService, TokenService>();

            var key = Encoding.ASCII.GetBytes(configuration["JwtSettings:Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }
    }
}
