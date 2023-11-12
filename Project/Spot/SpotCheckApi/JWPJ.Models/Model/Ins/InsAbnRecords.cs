
namespace JWPJ.Models;

/// <summary>
/// 异常/维修统计表
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_ABN_RECORDS")]
public class InsAbnRecords:ModelBase
{
    /// <summary>
    ///  编号
    ///</summary>
    [SugarColumn(ColumnName = "CODE")]
    public string Code { get; set; }
    /// <summary>
    ///  名称
    ///</summary>
    [SugarColumn(ColumnName="NAME" )]
     public string Name { get; set; }
    /// <summary>
    ///  描述
    ///</summary>
     [SugarColumn(ColumnName="DESCRIBE" )]
     public string Describe { get; set; }

    /// <summary>
    /// 维修类型 
    ///</summary>
     [SugarColumn(ColumnName="WXCLASS" )]
     public string Wxclass { get; set; }
    /// <summary>
    /// 维修内容 
    ///</summary>
     [SugarColumn(ColumnName="WXCONTENT" )]
     public string Wxcontent { get; set; }
    /// <summary>
    /// 维修反馈 
    ///</summary>
     [SugarColumn(ColumnName="WXFEEDBACK" )]
     public string Wxfeedback { get; set; }
    /// <summary>
    /// 维修人 
    ///</summary>
     [SugarColumn(ColumnName="WXPERSON" )]
     public string Wxperson { get; set; }

    /// <summary>
    /// 工时 
    ///</summary>
    [SugarColumn(ColumnName = "USETIME")]
    public decimal? Usetime { get; set; }
    /// <summary>
    /// 人力 
    ///</summary>
    [SugarColumn(ColumnName = "MANPOWER")]
    public decimal? Manpower { get; set; }
    /// <summary>
    /// 费用 
    ///</summary>
    [SugarColumn(ColumnName = "COST")]
    public decimal? Cost { get; set; }

}
