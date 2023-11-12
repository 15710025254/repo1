
namespace JWPJ.Core;

/// <summary>
/// 数据库配置选项
/// </summary>
public sealed class DbConnectionOptions : IConfigurableOptions<DbConnectionOptions>
{
    /// <summary>
    /// 启用控制台打印SQL
    /// </summary>
    public bool EnableConsoleSql { get; set; }

    /// <summary>
    /// 是否开启多库模式
    /// </summary>
    public bool MutiDBEnabled { get; set; }

    /// <summary>
    /// 当前项目的主库，所对应的连接字符串的Enabled必须为true
    /// </summary>
    public string MainDB { get; set; }

    /// <summary>
    /// 数据库集合
    /// </summary>
    public List<DbConnectionConfig> ConnectionConfigs { get; set; }

    public void PostConfigure(DbConnectionOptions options, IConfiguration configuration)
    {
        //foreach (var dbConfig in options.ConnectionConfigs)
        //{
        //    if (string.IsNullOrWhiteSpace(dbConfig.ConfigId))
        //        dbConfig.ConfigId = SqlSugarConst.MainConfigId;
        //}
    }
}

/// <summary>
/// 数据库连接配置
/// </summary>
public sealed class DbConnectionConfig : ConnectionConfig
{
    
}
