
namespace JWPJ.Models;

/// <summary>
/// 归属分类-类型枚举
/// </summary>
[Description("归属分类-类型枚举")]
public enum ClassifyEnum
{
    /// <summary>
    /// 系统
    /// </summary>
    [Description("系统")]
    System = 0,
    /// <summary>
    /// 区域
    /// </summary>
    [Description("区域")]
    Arear = 1,
    /// <summary>
    /// 线体
    /// </summary>
    [Description("线体")]
    Line = 2,
    /// <summary>
    /// 机台
    /// </summary>
    [Description("机台")]
    Machine = 3,
}
