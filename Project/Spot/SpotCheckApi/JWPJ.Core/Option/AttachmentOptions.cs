
namespace JWPJ.Core;

public sealed class AttachmentOptions : IConfigurableOptions
{
    /// <summary>
    /// 路径
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// 大小
    /// </summary>
    public long MaxSize { get; set; }

    /// <summary>
    /// 上传格式
    /// </summary>
    public List<string> ContentType { get; set; }
}
