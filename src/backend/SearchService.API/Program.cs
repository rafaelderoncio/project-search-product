using SearchService.Core.Extensions;
using SearchService.Core.Repositories.Interfaces;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(x => x.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new ()
    {
        Title = "Catalog API",
        Version = "v1",
    });
});

builder.Services.AddControllers();

builder.Services.AddHealthChecks();

builder.Services.AddMemoryCache();

builder.Services.AddServices();

builder.Services.AddDbContext(builder.Configuration, builder.Environment.EnvironmentName);

builder.Services.AddRepositories();

builder.Services.AddCorsCustom();

builder.Logging.AddConsole();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API v1");
    options.RoutePrefix = string.Empty;
});

app.UseCorsCustom(app.Environment.EnvironmentName);

app.UseHealthChecks("/health");

app.MapControllers();

app.Services.GetRequiredService<ICatalogCacheRepository>().InitializeCache().GetAwaiter();

app.Run();