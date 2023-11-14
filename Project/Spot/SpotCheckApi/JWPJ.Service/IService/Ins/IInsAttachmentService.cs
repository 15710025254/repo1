
using Furion.VirtualFileServer;
using Furion;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using Yitter.IdGenerator;

namespace JWPJ.Service;

/// <summary>
/// 附件表
/// </summary>
public interface IInsAttachmentService : ITransient
{
    /// <summary>
    /// 附件 分页查询
    /// </summary>
    /// <returns></returns>
    Task<PageResult<InsAttachment>> GetInsAttachmentPageList(InsAttachmentInputDto param);

    /// <summary>
    /// 附件 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task<InsAttachment> AddInsAttachment(IFormFile file, string tableName, string batchNo = "", string savePath = "");

    /// <summary>
    /// 附件 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
     Task DelInsAttachment(long Id);
}
