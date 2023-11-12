
namespace JWPJ.Models;

/// <summary>
/// 设备基础信息
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_EQUIPMENT_INF")]
public class InsEquipmentInf:ModelBase
{
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="OLDCODE" )]
     public string Oldcode { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="GCODE" )]
     public string Gcode { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="NAME" )]
     public string Name { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="CODE" )]
     public string Code { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="SFROM" )]
     public string Sfrom { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="DESCRIBE" )]
     public string Describe { get; set; }

    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="STORAGEAREA" )]
     public string Storagearea { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="LOCATION_X" )]
     public decimal? LocationX { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="LOCATION_Y" )]
     public decimal? LocationY { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="OWERDEPT" )]
     public string Owerdept { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="USEDEPT" )]
     public string Usedept { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="CUSTODIAN" )]
     public string Custodian { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="EQUIPMENTCLASS" )]
     public decimal? Equipmentclass { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="GSCLASS" )]
     public decimal? Gsclass { get; set; }
    /// <summary>
    /// 有效期 
    ///</summary>
     [SugarColumn(ColumnName="VALIDITY" )]
     public decimal? Validity { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="DJCLASS" )]
     public decimal? Djclass { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="BYCLASS" )]
     public decimal? Byclass { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="DJDEPT" )]
     public string Djdept { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="BYDEPT" )]
     public string Bydept { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="STATE" )]
     public decimal? State { get; set; }
    /// <summary>
    /// 以图片形式显示设备信息 
    ///</summary>
     [SugarColumn(ColumnName="IMAGES" )]
     public string Images { get; set; }
}
