
namespace JWPJ.Models;

/// <summary>
/// 设备状态
/// </summary>
[Description("设备状态")]
public enum EquipmentStateEnum
{
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    Normal =1,
    /// <summary>
    /// 带病运行
    /// </summary>
    [Description("带病运行")]
    FailSafeOper = 2,
    /// <summary>
    /// 故障
    /// </summary>
    [Description("故障")]
    Fault = 3,
}
