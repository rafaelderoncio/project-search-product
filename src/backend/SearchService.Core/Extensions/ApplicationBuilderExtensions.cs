using SearchService.Domain.Enum;

namespace SearchService.Core.Extensions;

public static class ApplicationBuilderExtensions
{
    
    public static IApplicationBuilder UseCorsCustom(this IApplicationBuilder app, string environment)
    {
        if (environment == EnvironmentEnum.Development.GetDescription())
        {
            app.UseCors("DevPolicy");
            app.UseSwagger();
            app.UseSwaggerUI();
        } else if (environment == EnvironmentEnum.Production.GetDescription())
        {
            app.UseCors("ProdPolicy");
        }
        
        return app;
    }
}
