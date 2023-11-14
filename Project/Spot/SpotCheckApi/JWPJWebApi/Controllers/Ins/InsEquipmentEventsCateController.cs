
namespace JWPJWebApi.Controllers;

/// <summary>
/// 设备事件类型
/// </summary>
[ApiDescriptionSettings(Name = "InsEquipmentEventsCate", Order = 80)]
[Route("api/InsEquipmentEventsCate")]
public class InsEquipmentEventsCateController : IDynamicApiController
{
    private readonly IInsEquipmentEventsCateService _InsEquipmentEventsCateService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="InsEquipmentEventsCateService"></param>
    public InsEquipmentEventsCateController(IInsEquipmentEventsCateService InsEquipmentEventsCateService)
    {
        _InsEquipmentEventsCateService = InsEquipmentEventsCateService;
    }
    /// <summary>
    ///  设备事件类型 分页查询
    /// </summary>
    /// <returns></returns>
    [HttpPost("GetInsEquipmentEventsCatePageList")]
    public async Task<PageResult<InsEquipmentEventsCate>> GetInsEquipmentEventsCatePageList(InsEquipmentEventsCateInputDto param)
    {
        return await _InsEquipmentEventsCateService.GetInsEquipmentEventsCatePageList(param);
    }

    /// <summary>
    /// 设备事件类型 查询所有数据
    /// </summary>
    /// <param name="LangType">语言类型（1汉语，2英语）</param>
    /// <returns></returns>
    [HttpGet("GetInsEquipmentEventsCateList")]
    public async Task<List<InsEquipmentEventsCate>> GetInsEquipmentEventsCateList(LangTypeEnum? LangType)
    {
        return await _InsEquipmentEventsCateService.GetInsEquipmentEventsCateList(LangType);
    }

    /// <summary>
    /// 设备事件类型 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    [HttpPost("AddInsEquipmentEventsCate")]
    public async Task AddInsEquipmentEventsCate(AddInsEquipmentEventsCateInputDto param)
    {
        await _InsEquipmentEventsCateService.AddInsEquipmentEventsCate(param);
    }

    /// <summary>
    /// 设备事件类型 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    [HttpPost("UpdateInsEquipmentEventsCate")]
    public async Task UpdateInsEquipmentEventsCate(UpdateInsEquipmentEventsCateInputDto param)
    {
        await _InsEquipmentEventsCateService.UpdateInsEquipmentEventsCate(param);
    }

    /// <summary>
    /// 设备事件类型 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    [HttpPost("DelInsEquipmentEventsCate")]
    public async Task DelInsEquipmentEventsCate(long Id)
    {
        await _InsEquipmentEventsCateService.DelInsEquipmentEventsCate(Id);
    }
}
