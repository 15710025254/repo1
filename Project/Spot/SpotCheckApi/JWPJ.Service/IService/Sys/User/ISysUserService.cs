
namespace JWPJ.Service;

public interface ISysUserService:ITransient
{
    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    Task<PageResult<SysUser>> Page(PageUserInput param);

    /// <summary>
    /// 账号密码登录
    /// </summary>
    /// <param name="input"></param>
    /// <remarks>用户名/密码：superadmin/123456</remarks>
    /// <returns></returns>
    Task<SysUser> Login(LoginInputDto input);

    /// <summary>
    /// 增加用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<long> AddUser(AddUserInput input);

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateUser(UpdateUserInput input);
}
