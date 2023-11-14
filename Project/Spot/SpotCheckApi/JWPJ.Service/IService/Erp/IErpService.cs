
namespace JWPJ.Service;

/// <summary>
/// ERP服务
/// </summary>
public interface IErpService : ITransient
{
    /// <summary>
    /// ERP固资、列管数据读取
    /// </summary>
    /// <returns></returns>
    Task<List<ErpEquipmentDto>> ErpSyncData(string companyNo);
}
