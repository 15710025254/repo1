
namespace JWPJ.Models;


/// <summary>
/// 设备事件类型 查询
/// </summary>
public class InsEquipmentEventsCateInputDto : QueryCriteria
{
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 设备事件类型名称
    /// </summary>
    public string Name { get; set; }
}

/// <summary>
/// 设备事件类型 添加
/// </summary>
public class AddInsEquipmentEventsCateInputDto
{
    /// <summary>
    /// 设备事件类型名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string Describe { get; set; }
    /// <summary>
    /// 排序
    /// </summary>
    public int Num { get; set; }

    /// <summary>
    /// 语言类型
    /// </summary>
    public LangTypeEnum LangType { get; set; }

}

/// <summary>
/// 设备事件类型 修改参数
/// </summary>
public class UpdateInsEquipmentEventsCateInputDto : AddInsEquipmentEventsCateInputDto
{
    public long Id { get; set; }

}
