
namespace JWPJWebApi.Controllers;

/// <summary>
/// 设备
/// </summary>
[ApiDescriptionSettings(Name = "InsEquipmentInf", Order = 80)]
[Route("api/InsEquipmentInf")]
public class InsEquipmentInfController : IDynamicApiController
{
    private readonly IInsEquipmentInfService _InsEquipmentInfService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="InsEquipmentInfService"></param>
    public InsEquipmentInfController(IInsEquipmentInfService InsEquipmentInfService)
    {
        _InsEquipmentInfService = InsEquipmentInfService;
    }
    /// <summary>
    ///  设备 分页查询
    /// </summary>
    /// <returns></returns>
    [HttpPost("GetInsEquipmentInfPageList")]
    public async Task<PageResult<InsEquipmentInfOutputDto>> GetInsEquipmentInfPageList(InsEquipmentInfInputDto param)
    {
        return await _InsEquipmentInfService.GetInsEquipmentInfPageList(param);
    }

    /// <summary>
    /// 设备 添加
    /// </summary>
    /// <param name="img"></param>
    /// <param name="file"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    [HttpPost("AddInsEquipmentInf")]
    public async Task AddInsEquipmentInf(IFormFile img, IFormFile file, AddInsEquipmentInfInputDto param)
    {
        await _InsEquipmentInfService.AddInsEquipmentInf(img,file,param);
    }

    /// <summary>
    /// 设备 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    [HttpPost("UpdateInsEquipmentInf")]
    public async Task UpdateInsEquipmentInf(UpdateInsEquipmentInfInputDto param)
    {
        await _InsEquipmentInfService.UpdateInsEquipmentInf(param);
    }

    /// <summary>
    /// 设备 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    [HttpPost("DelInsEquipmentInf")]
    public async Task DelInsEquipmentInf(long Id)
    {
        await _InsEquipmentInfService.DelInsEquipmentInf(Id);
    }
}
