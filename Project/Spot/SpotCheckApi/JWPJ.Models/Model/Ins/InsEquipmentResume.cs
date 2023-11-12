
namespace JWPJ.Models;

/// <summary>
/// 设备履历
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_EQUIPMENT_RESUME")]
public class InsEquipmentResume:ModelBase
{

    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="CONTENT" )]
     public string Content { get; set; }

    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="CODE" )]
     public string Code { get; set; }
    
}
