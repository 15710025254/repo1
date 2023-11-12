

namespace JWPJ.Models;

/// <summary>
/// 设备类别 查询
/// </summary>
public class InsEquipmentCateInputDto : QueryCriteria
{
    /// <summary>
    /// 模版编号
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 设备类别名称
    /// </summary>
    public string Name { get; set; }
}

/// <summary>
/// 设备类别 添加
/// </summary>
public class AddInsEquipmentCateInputDto 
{
    /// <summary>
    /// 设备类别名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string Describe { get; set; }
    /// <summary>
    /// 排序
    /// </summary>
    public int? Num { get; set; }
}

/// <summary>
/// 设备类别 修改参数
/// </summary>
public class UpdateInsEquipmentCateInputDto: AddInsEquipmentCateInputDto
{
    public int Id { get; set; }

}
