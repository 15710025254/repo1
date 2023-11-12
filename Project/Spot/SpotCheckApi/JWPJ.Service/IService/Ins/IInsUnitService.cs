
namespace JWPJ.Service;

/// <summary>
/// 常量单位
/// </summary>
public interface IInsUnitService : ITransient
{
    /// <summary>
    ///  常量单位 分页查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    Task<PageResult<InsUnit>> GetInsUnitPageList(InsUnitInputDto param);

    /// <summary>
    ///  常量单位 查询所有数据
    /// </summary>
    /// <returns></returns>
    Task<List<InsUnit>> GetInsUnitList();

    /// <summary>
    /// 常量单位 添加
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task AddInsUnit(AddInsUnitInputDto param);

    /// <summary>
    /// 常量单位 修改
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task UpdateInsUnit(UpdateInsUnitInputDto param);

    /// <summary>
    /// 常量单位 删除
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    Task DelInsUnit(long Id);
}
