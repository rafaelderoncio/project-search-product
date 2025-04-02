using SearchService.Domain.Enum;

namespace SearchService.Core.Extensions;

public static class ApplicationBuilderExtensions
{
    
    public static IApplicationBuilder UseCorsCustom(this IApplicationBuilder app, string environment)
    {
        if (environment == nameof(EnvironmentEnum.Development))
        {
            app.UseCors("DevPolicy");
            app.UseSwagger();
            app.UseSwaggerUI();
        } else if (environment == nameof(EnvironmentEnum.Production))
        {
            app.UseCors("ProdPolicy");
        }
        
        return app;
    }
}
