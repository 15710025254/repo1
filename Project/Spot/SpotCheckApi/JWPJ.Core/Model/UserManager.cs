
namespace JWPJ.Core;

/// <summary>
/// 当前登录用户
/// </summary>
public class UserManager : IScoped
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    //private long _tenantId;

    public string UserId
    {
        get => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.UserId)?.Value;
    }

    //public long TenantId
    //{
    //    get
    //    {
    //        var tId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.TenantId)?.Value;
    //        return string.IsNullOrWhiteSpace(tId) ? _tenantId : long.Parse(tId);
    //    }
    //    set => _tenantId = value;
    //}

    public string Account
    {
        get => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.Account)?.Value;
    }

    public string AccountTemp
    {
        get => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.AccountTemp)?.Value;
    }

    public string Project
    {
        get => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.Project)?.Value;
    }

    public string Companyno
    {
        get => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.Companyno)?.Value;
    }

    public string DeptScope
    {
        get => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.DeptScope)?.Value;
    }

    public string Role
    {
        get => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimConst.Role)?.Value;
    }

    public UserManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
}
