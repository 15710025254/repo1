namespace JWPJ.Models;

/// <summary>
/// 用户登录结果
/// </summary>
public class LoginOutputDto
{
    /// <summary>
    /// 令牌Token
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// 刷新Token
    /// </summary>
    public string RefreshToken { get; set; }
}
