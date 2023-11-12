
namespace JWPJ.Models;

/// <summary>
/// 归属分类
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_CLASSIFY")]
public class InsClassify:ModelBase
{
    /// <summary>
    ///  编码
    ///</summary>
     [SugarColumn(ColumnName="CODE" )]
     public string Code { get; set; }
    /// <summary>
    ///  名称
    ///</summary>
    [SugarColumn(ColumnName = "NAME")]
    public string Name { get; set; }
    /// <summary>
    ///  类型
    ///</summary>
    [SugarColumn(ColumnName="STYPE" )]
     public ClassifyEnum Stype { get; set; }
    /// <summary>
    ///  归属
    ///</summary>
    [SugarColumn(ColumnName="BELONGING" )]
     public string Belonging { get; set; }
    /// <summary>
    ///  描述
    ///</summary>
     [SugarColumn(ColumnName="DESCRIBE" )]
     public string Describe { get; set; }

    /// <summary>
    /// 排序
    ///</summary>
    [SugarColumn(ColumnName = "NUM")]
    public int Num { get; set; }

}
