
namespace JWPJ.Models;

/// <summary>
/// 点检记录表
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_RECORDS")]
public class InsRecords:ModelBase
{

    /// <summary>
    /// 设备类别Code 
    ///</summary>
     [SugarColumn(ColumnName="EQCODE" )]
     public string Eqcode { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="DJDATE" )]
     public DateTime? Djdate { get; set; }
    /// <summary>
    /// 点检事项名称 
    ///</summary>
     [SugarColumn(ColumnName="NAME" )]
     public string Name { get; set; }
    /// <summary>
    /// 点检人 
    ///</summary>
     [SugarColumn(ColumnName="DJPERSON" )]
     public string Djperson { get; set; }
    /// <summary>
    /// 描述 
    ///</summary>
     [SugarColumn(ColumnName="DESCRIBE" )]
     public string Describe { get; set; }
    
    /// <summary>
    /// 防伪造企微经纬度手机范围 
    ///</summary>
     [SugarColumn(ColumnName="FORGEDIS" )]
     public decimal? Forgedis { get; set; }
    /// <summary>
    /// 佐证资料 
    ///</summary>
     [SugarColumn(ColumnName="RECORDIMGS" )]
     public string Recordimgs { get; set; }
    /// <summary>
    /// 单项OK，（全部OK） 
    ///</summary>
     [SugarColumn(ColumnName="STATE" )]
     public decimal? State { get; set; }
    /// <summary>
    /// 点检结果 
    ///</summary>
     [SugarColumn(ColumnName="RESULT" )]
     public string Result { get; set; }
}
