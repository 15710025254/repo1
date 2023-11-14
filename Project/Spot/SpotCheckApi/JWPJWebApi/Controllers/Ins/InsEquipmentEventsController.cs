
namespace JWPJWebApi.Controllers;

/// <summary>
/// 设备事件
/// </summary>
[ApiDescriptionSettings(Name = "InsEquipmentEvents", Order = 80)]
[Route("api/InsEquipmentEvents")]
public class InsEquipmentEventsController : IDynamicApiController
{
    private readonly IInsEquipmentEventsService _InsEquipmentEventsService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="InsEquipmentEventsService"></param>
    public InsEquipmentEventsController(IInsEquipmentEventsService InsEquipmentEventsService)
    {
        _InsEquipmentEventsService = InsEquipmentEventsService;
    }
    /// <summary>
    ///  设备事件 分页查询
    /// </summary>
    /// <returns></returns>
    [HttpPost("GetInsEquipmentEventsPageList")]
    public async Task<PageResult<InsEquipmentEventsOutputDto>> GetInsEquipmentEventsPageList(InsEquipmentEventsInputDto param)
    {
        return await _InsEquipmentEventsService.GetInsEquipmentEventsPageList(param);
    }

    /// <summary>
    /// 设备事件 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    [HttpPost("AddInsEquipmentEvents")]
    public async Task AddInsEquipmentEvents(AddInsEquipmentEventsInputDto param)
    {
        await _InsEquipmentEventsService.AddInsEquipmentEvents(param);
    }

    /// <summary>
    /// 设备事件 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    [HttpPost("UpdateInsEquipmentEvents")]
    public async Task UpdateInsEquipmentEvents(UpdateInsEquipmentEventsInputDto param)
    {
        await _InsEquipmentEventsService.UpdateInsEquipmentEvents(param);
    }

    /// <summary>
    /// 设备事件 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    [HttpPost("DelInsEquipmentEvents")]
    public async Task DelInsEquipmentEvents(long Id)
    {
        await _InsEquipmentEventsService.DelInsEquipmentEvents(Id);
    }
}
