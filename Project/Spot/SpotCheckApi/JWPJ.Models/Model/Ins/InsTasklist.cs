
namespace JWPJ.Models;

/// <summary>
/// 任务清单
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_TASKLIST")]
public class InsTasklist:ModelBase
{

    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="CODE")]
     public string Code { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="NAME")]
     public string Name { get; set; }

    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="INSJOB")]
     public string Insjob { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="PATH")]
     public string Path { get; set; }
    
}
