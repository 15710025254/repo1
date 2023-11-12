
namespace JWPJ.Models;


/// <summary>
/// 常量单位 查询
/// </summary>
public class InsUnitInputDto : QueryCriteria
{
    /// <summary>
    /// 编号
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 常量单位名称
    /// </summary>
    public string Name { get; set; }
}

/// <summary>
/// 常量单位 添加
/// </summary>
public class AddInsUnitInputDto
{
    /// <summary>
    /// 常量单位名称
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
/// 常量单位 修改参数
/// </summary>
public class UpdateInsUnitInputDto : AddInsUnitInputDto
{
    public long Id { get; set; }

}

