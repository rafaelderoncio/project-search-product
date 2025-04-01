using System.ComponentModel;

namespace SearchService.Domain.Enum;

public enum EnvironmentEnum
{
    [Description("prod")]
    Production,

    [Description("dev")]
    Development
}
