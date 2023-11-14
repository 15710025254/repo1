
namespace JWPJ.Models;


/// <summary>
/// 设备等级
/// </summary>
[Description("设备等级")]
public enum EquipmentLevelEnum
{
    /// <summary>
    /// A(关键)
    /// </summary>
    [Description("A(关键)")]
    A = 1,
    /// <summary>
    /// B(重要)
    /// </summary>
    [Description("B(重要)")]
    B = 2,
    /// <summary>
    /// C(一般)
    /// </summary>
    [Description("C(一般)")]
    C = 3,
    /// <summary>
    /// D
    /// </summary>
    [Description("D")]
    D = 4,
}
