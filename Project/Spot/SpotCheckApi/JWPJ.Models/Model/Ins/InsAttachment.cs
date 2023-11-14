
namespace JWPJ.Models;

/// <summary>
/// 附件表
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_ATTACHMENT")]
public class InsAttachment : ModelBase
{
    /// <summary>
    ///  所属表
    ///</summary>
    [SugarColumn(ColumnName = "TABLE_NAME")]
    public string TableName { get; set; }

    /// <summary>
    ///  批次号
    ///</summary>
    [SugarColumn(ColumnName = "BATCH_NO")]
    public string BatchNo { get; set; }

    /// <summary>
    ///  原文件名
    ///</summary>
    [SugarColumn(ColumnName = "FILE_NAME")]
    public string FileName { get; set; }

    /// <summary>
    ///  实际文件名称
    ///</summary>
    [SugarColumn(ColumnName = "REAL_FILE_NAME")]
    public string RealFileName { get; set; }

    /// <summary>
    /// 文件后缀
    ///</summary>
    [SugarColumn(ColumnName = "SUFFIX")]
    public string Suffix { get; set; }

    /// <summary>
    ///  存储路径
    ///</summary>
    [SugarColumn(ColumnName = "FILE_PATH")]
    public string FilePath { get; set; }

    /// <summary>
    ///  文件大小
    ///</summary>
    [SugarColumn(ColumnName = "FILE_SIZE")]
    public long FileSize { get; set; }

    /// <summary>
    ///  描述
    ///</summary>
    [SugarColumn(ColumnName = "DESCRIBE")]
    public string Describe { get; set; }

}
