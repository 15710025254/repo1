
namespace JWPJWebApi.Controllers;

/// <summary>
/// 归属分类
/// </summary>
[ApiDescriptionSettings(Name = "InsClassify", Order = 90)]
[Route("api/InsClassify")]
public class InsClassifyController : IDynamicApiController
{
    private readonly IInsClassifyService _insClassifyService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="insClassifyService"></param>
    public InsClassifyController(IInsClassifyService insClassifyService)
    {
        _insClassifyService = insClassifyService;
    }

    /// <summary>
    ///  归属分类 查询TreeList
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    [HttpPost("GetInsClassifyList")]
    public async Task<List<InsClassify>> GetInsClassifyList(InsClassifyInputDto param)
    {
        return await _insClassifyService.GetInsClassifyList(param);
    }

    /// <summary>
    /// 归属分类 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    [HttpPost("AddInsClassify")]
    public async Task<decimal> AddInsClassify(AddInsClassifyInputDto param)
    {
        return await _insClassifyService.AddInsClassify(param);
    }

    /// <summary>
    /// 归属分类 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    [HttpPost("UpdateInsClassify")]
    public async Task UpdateInsClassify(UpdateInsClassifyInputDto param)
    {
         await _insClassifyService.UpdateInsClassify(param);
    }

    /// <summary>
    /// 归属分类 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    [HttpPost("DelInsClassify")]
    public async Task DelInsClassify(long Id)
    {
         await _insClassifyService.DelInsClassify(Id);
    }
}
