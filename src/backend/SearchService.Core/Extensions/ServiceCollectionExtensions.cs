using Microsoft.EntityFrameworkCore;
using SearchService.Core.Repositories;
using SearchService.Core.Repositories.Interfaces;
using SearchService.Core.Services;
using SearchService.Core.Services.Interfaces;
using SearchService.Domain.Enum;

namespace SearchService.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorsCustom(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("DevPolicy",
                policy => policy.AllowAnyOrigin()
                    .WithMethods("GET")
                    .WithHeaders("X-Dev"));


            options.AddPolicy("ProdPolicy",
                policy => policy.AllowAnyOrigin()
                    .WithMethods("GET")
                    .WithHeaders("X-Prod"));
        });

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ICatalogService, CatalogService>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ICatalogCacheRepository, CatalogCacheRepository>();
        services.AddTransient<ICatalogRepository, CatalogRepository>();

        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config, string environment)
    {
        if (environment == nameof(EnvironmentEnum.Development))
        {
            services.AddDbContext<CatalogContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        }
        else if (environment == nameof(EnvironmentEnum.Production))
        {
            string host = Environment.GetEnvironmentVariable("DATABASE_HOST");
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT");
            string database = Environment.GetEnvironmentVariable("DATABASE_DATABASE");
            string username = Environment.GetEnvironmentVariable("DATABASE_USERNAME");
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

            string connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";

            services.AddDbContext<CatalogContext>(options =>
                options.UseNpgsql(connectionString));
        }
        else
        {
            services.AddDbContext<CatalogContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));
        }

        return services;
    }

}
