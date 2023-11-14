
namespace JWPJ.Service;

public class SysUserService : SqlSugarRepository<SysUser>, ISysUserService
{
    private readonly ILogger<SysUserService> _logger;
    private readonly SqlSugarRepository<SysUser> _sysUserRep;
    private readonly ISqlSugarClient _db;
    public SysUserService(ILogger<SysUserService> logger, SqlSugarRepository<SysUser> sysUserRep, ISqlSugarClient db)
    {
        _logger = logger;
        _sysUserRep = sysUserRep;
        _db = db;
    }

    /// <summary>
    /// 获取用户分页列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PageResult<SysUser>> Page(PageUserInput param)
    {
        List<string> createBys = new List<string>();
       var data = await _sysUserRep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(param.Account), x => x.Companyno.Contains(param.Account))
            .WhereIF(!string.IsNullOrWhiteSpace(param.Account), x => x.Account.Contains(param.Account))
            .WhereIF(!string.IsNullOrWhiteSpace(param.RealName), x => x.RealName.Contains(param.RealName))
            .OrderBy(x => x.OrderNo)
            .ToPageListAsync(param.PageIndex,param.PageSize);

       return await _sysUserRep.GetPageListAsync(x=>x.IsPhantom==0,param.PageIndex,param.PageSize);
    }

    /// <summary>
    /// 账号密码登录
    /// </summary>
    /// <param name="input"></param>
    /// <remarks>用户名/密码：superadmin/123456</remarks>
    /// <returns></returns>
    public async Task<SysUser> Login(LoginInputDto input)
    {
        // 账号是否存在
        var user = await _sysUserRep.AsQueryable().Filter(null, true).FirstAsync(u => u.Account.Equals(input.Account));
        return user;
    }

    /// <summary>
    /// 增加用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<decimal> AddUser(AddUserInput input)
    {
        var isExist = await _sysUserRep.AsQueryable().Filter(null, true).AnyAsync(u => u.Account == input.Account);
        if (isExist)
            throw Oops.Oh(ErrorCodeEnum.D0008);
        var user = input.Adapt<SysUser>();
        var newUser = await _sysUserRep.InsertReturnEntityAsync(user);
        return newUser.Id;
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [UnitOfWork]
    public async Task UpdateUser(UpdateUserInput input)
    {
        if (await _sysUserRep.AsQueryable().Filter(null, true).AnyAsync(u => u.Account == input.Account && u.Id != input.Id))
            throw Oops.Oh(ErrorCodeEnum.D0010);

        await _sysUserRep.AsUpdateable(input.Adapt<SysUser>()).IgnoreColumns(true)
            .IgnoreColumns(u => new { u.AccountType, u.Password, u.Status }).ExecuteCommandAsync();
    }

}

