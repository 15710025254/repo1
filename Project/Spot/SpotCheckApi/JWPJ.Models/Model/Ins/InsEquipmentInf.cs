
using Furion.InstantMessaging;

namespace JWPJ.Models;

/// <summary>
/// 设备基础信息
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_EQUIPMENT_INF")]
public class InsEquipmentInf : ModelBase
{
    /// <summary>
    ///  图片
    ///</summary>
    [SugarColumn(ColumnName = "IMG")]
    public string Img { get; set; }

    /// <summary>
    /// 图片（反向导航，第一个主表字段，第二个子表字段）
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    [Navigate(NavigateType.OneToOne, nameof(Img), nameof(InsAttachment.BatchNo))]
    public InsAttachment AttachmentImg { get; set; }

    /// <summary>
    ///  设备编号
    ///</summary>
    [SugarColumn(ColumnName = "CODE")]
    public string Code { get; set; }
    /// <summary>
    ///  旧设备编号
    ///</summary>
    [SugarColumn(ColumnName = "OLD_CODE")]
    public string Oldcode { get; set; }
    /// <summary>
    /// 设备名称
    ///</summary>
    [SugarColumn(ColumnName = "NAME")]
    public string Name { get; set; }

    /// <summary>
    ///  资产编号（固资/列管）
    ///</summary>
    [SugarColumn(ColumnName = "GCODE")]
    public string Gcode { get; set; }
    /// <summary>
    /// 序列号
    ///</summary>
    [SugarColumn(ColumnName = "SERIAL_NUMBER")]
    public string SerialNumber { get; set; }

    /// <summary>
    /// 设备类别ID
    ///</summary>
    [SugarColumn(ColumnName = "INS_EQUIPMENT_CATE_ID")]
    public decimal InsEquipmentCateId { get; set; }

    /// <summary>
    /// 设备类别（主键导航，主表的InsEquipmentCateId关联子表的主键ID）
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    [Navigate(NavigateType.OneToOne, nameof(InsEquipmentCateId))]
    public InsEquipmentCate EquipmentCate { get; set; }

    /// <summary>
    ///  设备状态
    ///</summary>
    [SugarColumn(ColumnName = "STATE")]
    public EquipmentStateEnum State { get; set; } = EquipmentStateEnum.Normal;

    /// <summary>
    ///  设备使用状态
    ///</summary>
    [SugarColumn(ColumnName = "ON_STATE")]
    public EquipmentOnStateEnum OnState { get; set; }

    /// <summary>
    ///  负责人工号
    ///</summary>
    [SugarColumn(ColumnName = "HEAD_NO")]
    public string HeadNo { get; set; }

    /// <summary>
    ///  负责人
    ///</summary>
    [SugarColumn(ColumnName = "HEAD")]
    public string Head { get; set; }

    /// <summary>
    /// 品牌
    /// </summary>
    [SugarColumn(ColumnName = "BRAND")]
    public string Brand { get; set; }

    /// <summary>
    /// 规格型号
    /// </summary>
    [SugarColumn(ColumnName = "SPEC")]
    public string Spec { get; set; }

    /// <summary>
    ///  设备等级
    ///</summary>
    [SugarColumn(ColumnName = "EQUIPMENT_LEVEL")]
    public EquipmentLevelEnum EquipmentLevel { get; set; }

    /// <summary>
    ///  所属部门（部门ID）
    ///</summary>
    [SugarColumn(ColumnName = "DEPART_ID")]
    public string DepartId { get; set; }

    /// <summary>
    ///  所属部门（部门名称）
    ///</summary>
    [SugarColumn(ColumnName = "DEPART_Name")]
    public string DepartName { get; set; }

    /// <summary>
    ///  使用部门（部门ID）
    ///</summary>
    [SugarColumn(ColumnName = "USER_DEPART_ID")]
    public string UserDepartId { get; set; }

    /// <summary>
    ///  使用部门（部门名称）
    ///</summary>
    [SugarColumn(ColumnName = "USER_DEPART_NAME")]
    public string UserDepartName { get; set; }

    /// <summary>
    ///  功能位置（区域ID）
    ///</summary>
    [SugarColumn(ColumnName = "INS_CLASSIFY_ID")]
    public decimal? InsClassifyId { get; set; }

    /// <summary>
    /// 功能位置（主键导航 主表的InsClassifyId关联子表的主键ID）
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    [Navigate(NavigateType.OneToOne, nameof(InsClassifyId))]
    public InsClassify Classify { get; set; }

    /// <summary>
    ///  单位ID
    ///</summary>
    [SugarColumn(ColumnName = "INS_UNIT_ID")]
    public decimal? InsUnitId { get; set; }

    /// <summary>
    /// 单位（主键导航 主表的InsUnitId关联子表的主键ID）
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    [Navigate(NavigateType.OneToOne, nameof(InsUnitId))]
    public InsUnit Unit { get; set; }

    /// <summary>
    ///  供应商名称
    ///</summary>
    [SugarColumn(ColumnName = "SUPPLIER")]
    public string Supplier { get; set; }

    /// <summary>
    /// 购置日期
    ///</summary>
    [SugarColumn(ColumnName = "ACQUISITION_DATE")]
    public DateTime? AcquisitionDate { get; set; }

    /// <summary>
    ///  采购金额
    ///</summary>
    [SugarColumn(ColumnName = "PURCHASE_AMOUNT")]
    public decimal? PurchaseAmount { get; set; }

    /// <summary>
    ///  币别
    ///</summary>
    [SugarColumn(ColumnName = "CURRENCY")]
    public CurrencyEnum? Currency { get; set; }

    /// <summary>
    ///  保修期至
    ///</summary>
    [SugarColumn(ColumnName = "WARRANTY_DATE_TO")]
    public DateTime? WarrantyDateTo { get; set; }

    /// <summary>
    ///  启用日期
    ///</summary>
    [SugarColumn(ColumnName = "ACTIVATION_DATE")]
    public DateTime? ActivationDate { get; set; }

    /// <summary>
    ///  预计报废日期
    ///</summary>
    [SugarColumn(ColumnName = "EXPECTED_SCRAP_DATE")]
    public DateTime? ExpectedScrapDate { get; set; }

    /// <summary>
    ///  净值
    ///</summary>
    [SugarColumn(ColumnName = "NET_WORTH")]
    public decimal? NetWorth { get; set; }

    /// <summary>
    ///  设备来源
    ///</summary>
    [SugarColumn(ColumnName = "SOURCE")]
    public SourceEnum Source { get; set; } = SourceEnum.System;

    /// <summary>
    /// 设备参数
    ///</summary>
    [SugarColumn(ColumnName = "EQUIPMENT_PARAMETERS")]
    public string EquipmentParameters { get; set; }

    /// <summary>
    /// 附件批次号
    ///</summary>
    [SugarColumn(ColumnName = "FILE_BATCH_NO")]
    public string FileBatchNo { get; set; }

    /// <summary>
    /// 附件(反向导航 第一个是主表字段，第二个是子表字段)
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    [Navigate(NavigateType.OneToMany, nameof(FileBatchNo), nameof(InsAttachment.BatchNo))]
    public List<InsAttachment> Attachment { get; set; }

    /// <summary>
    /// 设备描述
    ///</summary>
    [SugarColumn(ColumnName = "DESCRIBE")]
    public string Describe { get; set; }

    /// <summary>
    /// 电子标签码
    ///</summary>
    [SugarColumn(ColumnName = "LABEL_CODE")]
    public string LabelCode { get; set; }

    ///// <summary>
    ///// 父ID
    /////</summary>
    //[SugarColumn(ColumnName = "PID")]
    //public decimal Pid { get; set; } 

}
