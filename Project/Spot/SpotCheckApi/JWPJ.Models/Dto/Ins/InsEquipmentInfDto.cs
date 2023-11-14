
namespace JWPJ.Models;

/// <summary>
/// 设备信息 分页查询参数
/// </summary>
public class InsEquipmentInfInputDto:QueryCriteria
{
    /// <summary>
    ///  设备编号
    ///</summary>
    public string Code { get; set; }
    /// <summary>
    ///  旧设备编号
    ///</summary>
    public string Oldcode { get; set; }

    /// <summary>
    /// 设备名称
    ///</summary>
    public string Name { get; set; }

    /// <summary>
    ///  资产编号（固资/列管）
    ///</summary>
    public string Gcode { get; set; }

    /// <summary>
    /// 设备类别ID
    ///</summary>
    public long? InsEquipmentCateId { get; set; }

    /// <summary>
    ///  设备状态
    ///</summary>
    public EquipmentStateEnum? State { get; set; }

    /// <summary>
    ///  设备使用状态
    ///</summary>
    public EquipmentOnStateEnum? OnState { get; set; }

    /// <summary>
    ///  负责人
    ///</summary>
    public string Head { get; set; }
}

/// <summary>
/// 设备信息 添加参数
/// </summary>
public class AddInsEquipmentInfInputDto
{
    /// <summary>
    ///  旧设备编号
    ///</summary>
    public string Oldcode { get; set; }

    /// <summary>
    /// 设备名称
    ///</summary>
    [Required(ErrorMessage = "设备名称不能为空")]
    public string Name { get; set; }

    /// <summary>
    ///  资产编号（固资/列管）
    ///</summary>
    public string Gcode { get; set; }
    /// <summary>
    /// 序列号
    ///</summary>
    public string SerialNumber { get; set; }

    /// <summary>
    /// 设备类别ID
    ///</summary>
    public long InsEquipmentCateId { get; set; }

    /// <summary>
    ///  设备状态
    ///</summary>
    public EquipmentStateEnum State { get; set; }

    /// <summary>
    ///  设备使用状态
    ///</summary>
    public EquipmentOnStateEnum OnState { get; set; }

    /// <summary>
    ///  负责人
    ///</summary>
    public string HeadNo { get; set; }

    /// <summary>
    ///  负责人工号
    ///</summary>
    public string Head { get; set; }

    /// <summary>
    /// 品牌
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// 规格型号
    /// </summary>
    public string Spec { get; set; }

    /// <summary>
    ///  设备等级
    ///</summary>
    public EquipmentLevelEnum EquipmentLevel { get; set; }

    /// <summary>
    ///  所属部门（部门ID）
    ///</summary>
    public string DepartId { get; set; }

    /// <summary>
    ///  所属部门（部门名称）
    ///</summary>
    public string DepartName { get; set; }

    /// <summary>
    ///  使用部门（部门ID）
    ///</summary>
    public string UserDepartId { get; set; }

    /// <summary>
    ///  使用部门（部门名称）
    ///</summary>
    public string UserDepartName { get; set; }

    /// <summary>
    ///  功能位置（区域ID）
    ///</summary>
    public long? InsClassifyId { get; set; }

    /// <summary>
    ///  单位ID
    ///</summary>
    public long? InsUnitId { get; set; }

    /// <summary>
    ///  供应商名称
    ///</summary>
    public string Supplier { get; set; }

    /// <summary>
    /// 购置日期
    ///</summary>
    public DateTime? AcquisitionDate { get; set; }

    /// <summary>
    ///  采购金额
    ///</summary>
    public decimal? PurchaseAmount { get; set; }

    /// <summary>
    ///  币别
    ///</summary>
    public CurrencyEnum? Currency { get; set; }

    /// <summary>
    ///  保修期至
    ///</summary>
    public DateTime? WarrantyDateTo { get; set; }

    /// <summary>
    ///  启用日期
    ///</summary>
    public DateTime? ActivationDate { get; set; }

    /// <summary>
    ///  预计报废日期
    ///</summary>
    public DateTime? ExpectedScrapDate { get; set; }

    /// <summary>
    ///  净值
    ///</summary>
    public decimal? NetWorth { get; set; }

    /// <summary>
    ///  设备来源
    ///</summary>
    public SourceEnum Source { get; set; }

    /// <summary>
    /// 设备参数
    ///</summary>
    public string EquipmentParameters { get; set; }

    /// <summary>
    /// 设备描述
    ///</summary>
    public string Describe { get; set; }

    /// <summary>
    /// 电子标签码
    ///</summary>
    public string LabelCode { get; set; }

    /// <summary>
    /// 父ID
    ///</summary>
    public long Pid { get; set; }
}

/// <summary>
/// 设备信息 修改参数
/// </summary>
public class UpdateInsEquipmentInfInputDto: AddInsEquipmentInfInputDto
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }

}

/// <summary>
/// 设备信息 查询列表输出参数
/// </summary>
public class InsEquipmentInfOutputDto:InsEquipmentInf
{ 
    /// <summary>
    /// 图片名称
    /// </summary>
    public string ImgName { get; set; }
    /// <summary>
    /// 设备类别名称
    /// </summary>
    public string EquipmentCateName { get; set; }

    /// <summary>
    /// 区域名称
    /// </summary>
    public string ClassifyName { get; set; }

    /// <summary>
    /// 单位
    /// </summary>
    public string UnitName { get; set; }

    /// <summary>
    /// 附件名称
    /// </summary>
    public string FileName { get; set; }
}