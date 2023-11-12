
namespace JWPJ.Models;

/// <summary>
/// 设备事件
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_EQUIPMENT_EVENTS")]
public class InsEquipmentEvents : ModelBase
{
    /// <summary>
    ///  事件编号
    ///</summary>
    [SugarColumn(ColumnName = "EVENT_NUMBER")]
    public string EventNumber { get; set; }
    /// <summary>
    ///  设备ID
    ///</summary>
    [SugarColumn(ColumnName = "INS_EQUIPMENT_INF_ID")]
    public decimal InsEquipmentInfId { get; set; }

    /// <summary>
    ///  设备事件类型ID
    ///</summary>
    [SugarColumn(ColumnName = "INS_EQUIPMENT_EVENTS_CATE_ID")]
    public decimal InsEquipmentEventsCateId { get; set; }

    /// <summary>
    ///  开销
    ///</summary>
    [SugarColumn(ColumnName = "SPEND")]
    public decimal Spend { get; set; }

    /// <summary>
    ///  价值变动（是、否）
    ///</summary>
    [SugarColumn(ColumnName = "IS_CHANGE_VALUE")]
    public StatusEnum IsChangeValue { get; set; }

    /// <summary>
    ///  变动值
    ///</summary>
    [SugarColumn(ColumnName = "VARIABLE_VALUE")]
    public decimal VariableValue { get; set; }

    /// <summary>
    ///  资产原值
    ///</summary>
    [SugarColumn(ColumnName = "COST")]
    public decimal Cost { get; set; }

    /// <summary>
    ///  变更后价值
    ///</summary>
    [SugarColumn(ColumnName = "VALUE_AFTER_CHANGE")]
    public decimal ValueAfterChange { get; set; }

    /// <summary>
    ///  发生日期
    ///</summary>
    [SugarColumn(ColumnName = "CUR_DATE")]
    public DateTime CurDate { get; set; }

    /// <summary>
    ///  描述
    ///</summary>
    [SugarColumn(ColumnName = "DESCRIBE")]
    public string Describe { get; set; }

}
