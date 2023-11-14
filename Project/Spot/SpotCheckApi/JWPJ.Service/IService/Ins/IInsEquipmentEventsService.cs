
namespace JWPJ.Service;

/// <summary>
/// 设备事件
/// </summary>
public interface IInsEquipmentEventsService : ITransient
{
    /// <summary>
    ///  设备事件 分页查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    Task<PageResult<InsEquipmentEventsOutputDto>> GetInsEquipmentEventsPageList(InsEquipmentEventsInputDto param);

    /// <summary>
    /// 设备事件 添加
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task AddInsEquipmentEvents(AddInsEquipmentEventsInputDto param);

    /// <summary>
    /// 设备事件 修改
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task UpdateInsEquipmentEvents(UpdateInsEquipmentEventsInputDto param);

    /// <summary>
    /// 设备事件 删除
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    Task DelInsEquipmentEvents(long Id);
}
