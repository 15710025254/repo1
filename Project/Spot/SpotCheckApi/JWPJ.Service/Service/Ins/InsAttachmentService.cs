

using Furion.VirtualFileServer;
using Furion;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using Yitter.IdGenerator;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JWPJ.Service;

public class InsAttachmentService : SqlSugarRepository<InsAttachment>, IInsAttachmentService
{
    private readonly ILogger<InsAttachmentService> _logger;
    private readonly SqlSugarRepository<InsAttachment> _repository;
    private readonly ISqlSugarClient _db;
    private readonly AttachmentOptions _uploadOptions;
    public InsAttachmentService(ILogger<InsAttachmentService> logger, SqlSugarRepository<InsAttachment> repository, ISqlSugarClient db, IOptions<AttachmentOptions> uploadOptions)
    {
        _logger = logger;
        _repository = repository;
        _db = db;
        _uploadOptions = uploadOptions.Value;
    }

    /// <summary>
    /// 附件 分页查询
    /// </summary>
    /// <returns></returns>
    public async Task<PageResult<InsAttachment>> GetInsAttachmentPageList(InsAttachmentInputDto param)
    {
        Expressionable<InsAttachment> whereLambda = Expressionable.Create<InsAttachment>();
        if (!string.IsNullOrWhiteSpace(param.TableName))
        {
            whereLambda.And((InsAttachment x) => x.TableName.Contains(param.TableName));
        }
        if (!string.IsNullOrWhiteSpace(param.FileName))
        {
            whereLambda.And((InsAttachment x) => x.FileName.Contains(param.FileName));
        }
        if (!string.IsNullOrWhiteSpace(param.Suffix))
        {
            whereLambda.And((InsAttachment x) => x.Suffix.Contains(param.Suffix));
        }
        PageResult<InsAttachment> list = await _repository.GetPageListAsync(whereLambda.ToExpression(), param.PageIndex, param.PageSize, x => x.CreateTime, OrderByType.Desc);        
        return list;
    }

    /// <summary>
    /// 附件 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task<InsAttachment> AddInsAttachment(IFormFile file, string tableName, string batchNo = "", string savePath = "")
    {
        if (file == null) throw Oops.Oh(ErrorCodeEnum.D3011);

        var path = savePath;
        if (string.IsNullOrWhiteSpace(savePath))
        {
            path = _uploadOptions.Path;
            var reg = new Regex(@"(\{.+?})");
            var match = reg.Matches(path);
            match.ToList().ForEach(a =>
            {
                var str = DateTime.Now.ToString(a.ToString().Substring(1, a.Length - 2)); // 每天一个目录
                path = path.Replace(a.ToString(), str);
            });
        }
        if (!_uploadOptions.ContentType.Contains(file.ContentType))
            throw Oops.Oh(ErrorCodeEnum.D3012);

        var sizeKb = (long)(file.Length / 1024.0); // 大小KB
        if (sizeKb > _uploadOptions.MaxSize)
            throw Oops.Oh(ErrorCodeEnum.D3013);

        var suffix = Path.GetExtension(file.FileName).ToLower(); // 后缀
        if (string.IsNullOrWhiteSpace(suffix))
        {
            var contentTypeProvider = FS.GetFileExtensionContentTypeProvider();
            suffix = contentTypeProvider.Mappings.FirstOrDefault(u => u.Value == file.ContentType).Key;
            // 修改 image/jpeg 类型返回的 .jpe 后缀
            if (suffix == ".jpe")
                suffix = ".jpg";
        }
        if (string.IsNullOrWhiteSpace(suffix))
            throw Oops.Oh(ErrorCodeEnum.D3014);

        if (string.IsNullOrWhiteSpace(batchNo))
            batchNo = Utils.RandomFileBatchNo();

        InsAttachment newFile = new InsAttachment();
        newFile.TableName = tableName;
        newFile.FileName = Path.GetFileNameWithoutExtension(file.FileName);
        newFile.Suffix = suffix;
        newFile.FileSize = sizeKb;
        newFile.FilePath = path;
        newFile.Id =Convert.ToDecimal(YitIdHelper.NextId());
        newFile.RealFileName = newFile.Id + suffix; // 服务器存储的文件名称
        newFile.BatchNo = batchNo;

        var filePath = Path.Combine(App.WebHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);

        var realFile = Path.Combine(filePath, newFile.RealFileName);
        using (var stream = File.Create(realFile))
        {
            await file.CopyToAsync(stream);
        }
        await _repository.AsInsertable(newFile).ExecuteCommandAsync();
        return newFile;
    }

    /// <summary>
    /// 附件 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    public async Task DelInsAttachment(long Id)
    {
        if (Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);

        InsAttachment insAttachment = await _repository.GetByIdAsync(Id);
        var filePath = Path.Combine(App.WebHostEnvironment.WebRootPath, insAttachment.FilePath, insAttachment.RealFileName);
        if (File.Exists(filePath))
            File.Delete(filePath);

        await _repository.UpdateAsync(x => x.Id == Id, it => new InsAttachment { IsPhantom = 1 });
    }
}
