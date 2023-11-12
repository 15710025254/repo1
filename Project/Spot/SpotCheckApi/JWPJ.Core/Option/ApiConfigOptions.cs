
namespace JWPJ.Core;


/// <summary>
/// 外部API配置选项
/// </summary>
public sealed class ApiConfigOptions :  IConfigurableOptions
{
    /// <summary>
    /// 外部API集合
    /// </summary>
    public List<ApiInfo> ApiList { get; set; }
}

public class ApiInfo
{
    /// <summary>
    /// API唯一标识
    /// </summary>
    public string ApiKey { get; set; }
    /// <summary>
    /// 公司别
    /// </summary>
    public string Companyno { get; set; }
    /// <summary>
    /// 登录名
    /// </summary>
    public string LoginName { get; set; }
    /// <summary>
    /// 密码
    /// </summary>
    public string LoginPwd { get; set; }
    /// <summary>
    /// URL
    /// </summary>
    public string Api { get; set; }
}
