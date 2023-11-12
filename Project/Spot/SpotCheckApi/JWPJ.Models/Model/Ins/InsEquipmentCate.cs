
namespace JWPJ.Models;

/// <summary>
/// 设备类别
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_EQUIPMENT_CATE")]
public class InsEquipmentCate:ModelBase
{

    /// <summary>
    /// 编号 
    ///</summary>
     [SugarColumn(ColumnName="CODE")]
     public string Code { get; set; }
    /// <summary>
    /// 名称 
    ///</summary>
    [SugarColumn(ColumnName = "NAME")]
    public string Name { get; set; }

    /// <summary>
    /// 描述 
    ///</summary>
    [SugarColumn(ColumnName = "DESCRIBE")]
    public string Describe { get; set; }

    /// <summary>
    /// 排序 
    ///</summary>
    [SugarColumn(ColumnName = "NUM")]
    public int Num { get; set; }

}
