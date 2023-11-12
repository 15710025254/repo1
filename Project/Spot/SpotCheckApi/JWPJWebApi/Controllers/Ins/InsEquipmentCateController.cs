
namespace JWPJWebApi.Controllers;

/// <summary>
/// 设备类别
/// </summary>
[ApiDescriptionSettings(Name = "InsEquipmentCate", Order = 99)]
[Route("api/InsEquipmentCate")]
public class InsEquipmentCateController : IDynamicApiController
{
    private readonly IInsEquipmentCateService _insEquipmentCateService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="insEquipmentCateService"></param>
    public InsEquipmentCateController(IInsEquipmentCateService insEquipmentCateService)
    {
        _insEquipmentCateService = insEquipmentCateService;
    }
    /// <summary>
    ///  设备类别 分页查询
    /// </summary>
    /// <returns></returns>
    [HttpPost("GetInsEquipmentCatePageList")]
    public async Task<PageResult<InsEquipmentCate>> GetInsEquipmentCatePageList(InsEquipmentCateInputDto param)
    {
       return await _insEquipmentCateService.GetInsEquipmentCatePageList(param);
    }

    /// <summary>
    /// 设备类别 查询所有数据
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetInsEquipmentCateList")]
    public async Task<List<InsEquipmentCate>> GetInsEquipmentCateList()
    {
        return await _insEquipmentCateService.GetInsEquipmentCateList();
    }

    /// <summary>
    /// 设备类别 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    [HttpPost("AddInsEquipmentCate")]
    public async Task AddInsEquipmentCate(AddInsEquipmentCateInputDto param)
    {
        await _insEquipmentCateService.AddInsEquipmentCate(param);
    }

    /// <summary>
    /// 设备类别 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    [HttpPost("UpdateInsEquipmentCate")]
    public async Task UpdateInsEquipmentCate(UpdateInsEquipmentCateInputDto param)
    {
        await _insEquipmentCateService.UpdateInsEquipmentCate(param);
    }

    /// <summary>
    /// 设备类别 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    [HttpPost("DelInsEquipmentCate")]
    public async Task DelInsEquipmentCate(long Id)
    {
        await _insEquipmentCateService.DelInsEquipmentCate(Id);
    }
}
