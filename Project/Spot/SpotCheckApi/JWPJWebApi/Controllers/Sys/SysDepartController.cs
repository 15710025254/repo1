
using NewLife.Reflection;

namespace JWPJWebApi.Controllers;

/// <summary>
/// 部门
/// </summary>
[ApiDescriptionSettings(Name = "SysDepart", Order = 998)]
[Route("api/SysDepart")]
public class SysDepartController : IDynamicApiController, ITransient
{
    private readonly UserManager _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISysCacheService _sysCacheService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    /// <param name="userManager"></param>
    /// <param name="sysCacheService"></param>
    public SysDepartController(IHttpContextAccessor httpContextAccessor, UserManager userManager, ISysCacheService sysCacheService)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _sysCacheService = sysCacheService;
    }

    /// <summary>
    /// 获取部门列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetDeparts")]
    public async Task<List<DepartDto>> GetDeparts()
    {
        //检查部门缓存是否存在
        if (!_sysCacheService.ExistKey(CacheConst.KeyDepart))
        {
            List<DepartDto> list = await SystemService.GetDeparts(_userManager.Companyno);
            _sysCacheService.Set(CacheConst.KeyDepart, list);
            return list;
        }
        return _sysCacheService.GetList<DepartDto>(CacheConst.KeyDepart).ToList();
    }

}
