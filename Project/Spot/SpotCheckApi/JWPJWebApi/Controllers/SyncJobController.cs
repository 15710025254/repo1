
namespace JWPJWebApi.Controllers;


/// <summary>
/// 执行job接口
/// </summary>
[ApiDescriptionSettings(Name = "SyncJob", Order = 1000)]
[Route("api/SyncJob")]
public class SyncJobController : IDynamicApiController
{
    private readonly ISysUserService _sysUserService;
    private readonly IErpService _erpService;
    private readonly IInsEquipmentInfService _insEquipmentInfService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sysUserService"></param>
    /// <param name="erpService"></param>
    /// <param name="insEquipmentInfService"></param>
    public SyncJobController(ISysUserService sysUserService, IErpService erpService, IInsEquipmentInfService insEquipmentInfService)
    {
        _sysUserService = sysUserService;
        _erpService = erpService;
        _insEquipmentInfService = insEquipmentInfService;
    }

    /// <summary>
    /// ERP固资、列管数据读取
    /// </summary>
    /// <returns></returns>
    [HttpGet("ErpSyncData")]
    public async Task<List<ErpEquipmentDto>> ErpSyncData(string[] companyNos)
    {
        List<ErpEquipmentDto> List = new List<ErpEquipmentDto>();
        foreach (var companyNo in companyNos)
        {
            List<ErpEquipmentDto> info =  await _erpService.ErpSyncData(companyNo);
            if (info != null) 
            {
                await _insEquipmentInfService.BeatchAddInsEquipmentInf(info);
                List.AddRange(info);
            }
        }
        return List;
    }
}
