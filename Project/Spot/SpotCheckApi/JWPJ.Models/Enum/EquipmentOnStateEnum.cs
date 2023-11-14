
namespace JWPJ.Models;

/// <summary>
/// 设备使用状态
/// </summary>
[Description("设备使用状态")]
public enum EquipmentOnStateEnum
{
    /// <summary>
    /// 闲置
    /// </summary>
    [Description("闲置")]
    UnUsed = 1,
    /// <summary>
    /// 禁用
    /// </summary>
    [Description("禁用")]
    Disable = 2,
    /// <summary>
    /// 在用
    /// </summary>
    [Description("在用")]
    InUse = 3,
    /// <summary>
    /// 出租
    /// </summary>
    [Description("出租")]
    Hire = 4,
    /// <summary>
    /// 废再利用
    /// </summary>
    [Description("废再利用")]
    Reuse = 5,
    /// <summary>
    /// 借机
    /// </summary>
    [Description("借机")]
    SeizeAnOpp = 6,
}
