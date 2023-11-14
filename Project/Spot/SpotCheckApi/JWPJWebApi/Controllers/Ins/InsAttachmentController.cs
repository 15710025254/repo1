
namespace JWPJWebApi.Controllers;

/// <summary>
/// 附件列表
/// </summary>
[Route("api/InsAttachment")]
[ApiController]
public class InsAttachmentController : IDynamicApiController
{
    private readonly IInsAttachmentService _InsAttachmentService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="InsAttachmentService"></param>
    public InsAttachmentController(IInsAttachmentService InsAttachmentService)
    {
        _InsAttachmentService = InsAttachmentService;
    }
    /// <summary>
    ///  附件 分页查询
    /// </summary>
    /// <returns></returns>
    [HttpPost("GetInsAttachmentPageList")]
    public async Task<PageResult<InsAttachment>> GetInsAttachmentPageList(InsAttachmentInputDto param)
    {
        return await _InsAttachmentService.GetInsAttachmentPageList(param);
    }
}
