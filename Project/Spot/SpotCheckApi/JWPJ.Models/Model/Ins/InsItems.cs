
namespace JWPJ.Models;

/// <summary>
/// 点检项目
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_ITEMS")]
public class InsItems:ModelBase
{
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="CODE" )]
     public decimal? Code { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="ITEMCODE" )]
     public decimal? Itemcode { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="ITEM" )]
     public string Item { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="BELONGING" )]
     public string Belonging { get; set; }

}
