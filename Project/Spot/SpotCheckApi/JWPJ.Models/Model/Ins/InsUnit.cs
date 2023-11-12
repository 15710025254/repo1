
namespace JWPJ.Models;

/// <summary>
/// 常量单位
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_UNIT")]
public class InsUnit:ModelBase
{
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="CODE" )]
     public string Code { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="NAME" )]
     public string Name { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="DESCRIBE" )]
     public string Describe { get; set; }
    
}
