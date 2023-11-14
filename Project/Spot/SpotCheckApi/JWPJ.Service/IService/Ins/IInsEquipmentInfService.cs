
using Microsoft.AspNetCore.Http;

namespace JWPJ.Service;

/// <summary>
/// 设备信息
/// </summary>
public interface IInsEquipmentInfService:ITransient
{
    /// <summary>
    ///  设备 分页查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    Task<PageResult<InsEquipmentInfOutputDto>> GetInsEquipmentInfPageList(InsEquipmentInfInputDto param);

    /// <summary>
    /// 设备 添加
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    Task AddInsEquipmentInf(IFormFile img, IFormFile file, AddInsEquipmentInfInputDto param);

    /// <summary>
    /// 设备 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task UpdateInsEquipmentInf(UpdateInsEquipmentInfInputDto param);

    /// <summary>
    /// 设备 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    Task DelInsEquipmentInf(long Id);

    /// <summary>
    /// 批量添加设备 同步ERP资产到系统
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
   Task BeatchAddInsEquipmentInf(List<ErpEquipmentDto> param);
}
