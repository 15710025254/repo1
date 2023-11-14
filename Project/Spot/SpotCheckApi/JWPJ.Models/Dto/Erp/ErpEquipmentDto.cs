
namespace JWPJ.Models;

/// <summary>
/// ERP固资列管
/// </summary>
public class ErpEquipmentDto
{
    /// <summary>
    /// 设备类型（固资/列管）
    /// </summary>
    public string EqumentType { get; set; }
    /// <summary>
    /// 财产编号
    /// </summary>
    public string PropertyNumber { get; set; }

    /// <summary>
    /// 资产类别
    /// </summary>
    public string AssetClass { get; set; }

    /// <summary>
    /// 资产类别名称
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// 中文名称-1
    /// </summary>
    public string CName { get; set; }

    /// <summary>
    /// 规格型号
    /// </summary>
    public string Spec { get; set; }

    /// <summary>
    /// 保管人工号
    /// </summary>
    public string CustodyLaborNo { get; set; }

    /// <summary>
    /// 保管人姓名
    /// </summary>
    public string CustodyLaborName { get; set; }

    /// <summary>
    /// 移转日期/入帐日期
    /// </summary>
    public DateTime? EntryDate { get; set; }
}
