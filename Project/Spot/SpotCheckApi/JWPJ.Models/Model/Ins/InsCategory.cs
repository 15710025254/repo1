
namespace JWPJ.Models;

/// <summary>
/// 点检类别
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_CATEGORY")]
public class InsCategory
{
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="CODE" )]
     public string Code { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="FVAL" )]
     public decimal? Fval { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="VUNIT" )]
     public string Vunit { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="STYPE" )]
     public decimal? Stype { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="BELONGING" )]
     public string Belonging { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="STANDARD" )]
     public string Standard { get; set; }
    /// <summary>
    ///  
    ///</summary>
     [SugarColumn(ColumnName="RESULT" )]
     public string Result { get; set; }
}
