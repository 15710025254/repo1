
namespace JWPJ.Models;


/// <summary>
/// 设备事件 查询
/// </summary>
public class InsEquipmentEventsInputDto : QueryCriteria
{
    /// <summary>
    ///  事件编号
    ///</summary>
    public string EventNumber { get; set; }
    /// <summary>
    ///  设备编号
    ///</summary>
    public string EquipmentCode { get; set; }

    /// <summary>
    ///  设备名称
    ///</summary>
    public string EquipmentName { get; set; }

    /// <summary>
    ///  设备事件类型ID
    ///</summary>
    public decimal? InsEquipmentEventsCateId { get; set; }

    /// <summary>
    ///  价值变动（是、否）
    ///</summary>
    public StatusEnum? IsChangeValue { get; set; }
}

/// <summary>
/// 设备事件 添加
/// </summary>
public class AddInsEquipmentEventsInputDto
{
    /// <summary>
    ///  设备ID
    ///</summary>
    public long InsEquipmentInfId { get; set; }

    /// <summary>
    ///  设备事件类型ID
    ///</summary>
    public long InsEquipmentEventsCateId { get; set; }

    /// <summary>
    ///  开销
    ///</summary>
    public decimal Spend { get; set; }

    /// <summary>
    ///  价值变动（是、否）
    ///</summary>
    public StatusEnum IsChangeValue { get; set; }

    /// <summary>
    ///  变动值
    ///</summary>
    public decimal VariableValue { get; set; }

    /// <summary>
    ///  资产原值
    ///</summary>
    public decimal Cost { get; set; }

    /// <summary>
    ///  变更后价值
    ///</summary>
    public decimal ValueAfterChange { get; set; }

    /// <summary>
    ///  发生日期
    ///</summary>
    public DateTime CurDate { get; set; }

    /// <summary>
    ///  描述
    ///</summary>
    public string Describe { get; set; }

}

/// <summary>
/// 设备事件 修改参数
/// </summary>
public class UpdateInsEquipmentEventsInputDto : AddInsEquipmentEventsInputDto
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }

}

/// <summary>
/// 设备事件 查询输出参数
/// </summary>
public class InsEquipmentEventsOutputDto: InsEquipmentEvents
{
    /// <summary>
    ///  设备编号
    ///</summary>
    public string EquipmentCode { get; set; }

    /// <summary>
    ///  设备名称
    ///</summary>
    public string EquipmentName { get; set; }

    /// <summary>
    ///  设备事件类型
    ///</summary>
    public string EquipmentEventsCate { get; set; }
}
