
namespace JWPJ.Service;

/// <summary>
/// 设备类别
/// </summary>
public interface IInsEquipmentCateService:ITransient
{
    /// <summary>
    ///  设备类别 分页查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    Task<PageResult<InsEquipmentCate>> GetInsEquipmentCatePageList(InsEquipmentCateInputDto param);

    /// <summary>
    ///  设备类别 查询所有数据
    /// </summary>
    /// <returns></returns>
    Task<List<InsEquipmentCate>> GetInsEquipmentCateList(LangTypeEnum? LangType);

    /// <summary>
    /// 设备类别 添加
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task AddInsEquipmentCate(AddInsEquipmentCateInputDto param);

    /// <summary>
    /// 设备类别 修改
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="param">参数</param>
    /// <returns></returns>
   Task UpdateInsEquipmentCate(UpdateInsEquipmentCateInputDto param);

    /// <summary>
    /// 设备类别 删除
    /// </summary>
    /// <param name="loginInfoDto">登陆信息</param>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    Task DelInsEquipmentCate(long Id);
}
