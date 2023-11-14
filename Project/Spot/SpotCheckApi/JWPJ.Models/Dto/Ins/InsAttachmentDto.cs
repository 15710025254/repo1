
namespace JWPJ.Models;

/// <summary>
/// 附件
/// </summary>
public class InsAttachmentInputDto:QueryCriteria
{
    /// <summary>
    ///  所属表
    ///</summary>
    public string TableName { get; set; }

    /// <summary>
    ///  文件名
    ///</summary>
    public string FileName { get; set; }

    /// <summary>
    /// 文件后缀
    ///</summary>
    public string Suffix { get; set; }

}

/// <summary>
/// 附件
/// </summary>
public class AddInsAttachmentInputDto
{
    /// <summary>
    ///  所属表
    ///</summary>
    public string TableName { get; set; }

    /// <summary>
    ///  文件名
    ///</summary>
    public string FileName { get; set; }

    /// <summary>
    /// 文件后缀
    ///</summary>
    public string Suffix { get; set; }

    /// <summary>
    ///  文件类型
    ///</summary>
    public string FileType { get; set; }

    /// <summary>
    ///  存储路径
    ///</summary>
    public string FilePath { get; set; }

    /// <summary>
    ///  文件大小
    ///</summary>
    public long FileSize { get; set; }

    /// <summary>
    ///  描述
    ///</summary>
    public string Describe { get; set; }
}
