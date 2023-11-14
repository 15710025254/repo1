
namespace JWPJ.Service;

/// <summary>
/// 设备事件类型
/// </summary>
public interface IInsEquipmentEventsCateService : ITransient
{
    /// <summary>
    ///  设备事件类型 分页查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    Task<PageResult<InsEquipmentEventsCate>> GetInsEquipmentEventsCatePageList(InsEquipmentEventsCateInputDto param);

    /// <summary>
    ///  设备事件类型 查询所有数据
    /// </summary>
    /// <returns></returns>
    Task<List<InsEquipmentEventsCate>> GetInsEquipmentEventsCateList(LangTypeEnum? LangType);

    /// <summary>
    /// 设备事件类型 添加
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task AddInsEquipmentEventsCate(AddInsEquipmentEventsCateInputDto param);

    /// <summary>
    /// 设备事件类型 修改
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task UpdateInsEquipmentEventsCate(UpdateInsEquipmentEventsCateInputDto param);

    /// <summary>
    /// 设备事件类型 删除
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    Task DelInsEquipmentEventsCate(long Id);
}
