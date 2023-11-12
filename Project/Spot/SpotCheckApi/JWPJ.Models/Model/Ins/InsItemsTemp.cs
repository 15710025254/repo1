
namespace JWPJ.Models;

/// <summary>
/// 点检项目模版
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_ITEMS_TEMP")]
public class InsItemsTemp:ModelBase
{
    /// <summary>
    ///  项目编号
    ///</summary>
    [SugarColumn(ColumnName = "CODE")]
    public string Code { get; set; }

    /// <summary>
    ///  模版名称
    ///</summary>
    [SugarColumn(ColumnName = "NAME")]
    public string Name { get; set; }

    /// <summary>
    ///  项目选项
    ///</summary>
    [SugarColumn(ColumnName="ITEM" )]
     public string Item { get; set; }

}
