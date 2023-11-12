
namespace JWPJ.Core;

public static class ProjectOptions
{
    /// <summary>
    /// 注册项目配置选项
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddProjectOptions(this IServiceCollection services)
    {
        services.AddConfigurableOptions<DbConnectionOptions>();
        services.AddConfigurableOptions<EnumOptions>();
        services.AddConfigurableOptions<SnowIdOptions>();
        services.AddConfigurableOptions<CacheOptions>();
        services.AddConfigurableOptions<LocalizationSettingsOptions>();
        services.AddConfigurableOptions<ApiConfigOptions>();
        return services;
    }
}
