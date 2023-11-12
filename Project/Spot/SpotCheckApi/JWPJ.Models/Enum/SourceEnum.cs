
namespace JWPJ.Models;

/// <summary>
/// 设备来源枚举
/// </summary>
[Description("设备来源枚举")]
public enum SourceEnum
{
    /// <summary>
    /// 本系统
    /// </summary>
    [Description("本系统")]
    System = 0,
    /// <summary>
    /// ERP
    /// </summary>
    [Description("ERP")]
    Erp = 1,
    /// <summary>
    /// MES
    /// </summary>
    [Description("MES")]
    Mes = 2,
}
