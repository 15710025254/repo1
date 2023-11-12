

namespace JWPJ.Models;

/// <summary>
/// 归属分类 查询参数
/// </summary>
public class InsClassifyInputDto
{
    /// <summary>
    ///  ID
    ///</summary>
    public long Id { get; set; }

    /// <summary>
    ///  编码
    ///</summary>
    public string Code { get; set; }

    /// <summary>
    ///  名称
    ///</summary>
    public string Name { get; set; }

    /// <summary>
    ///  类型
    ///</summary>
    public ClassifyEnum Stype { get; set; }
}

/// <summary>
/// 归属分类 添加参数
/// </summary>
public class AddInsClassifyInputDto
{
    /// <summary>
    ///  名称
    ///</summary>
    public string Name { get; set; }

    /// <summary>
    ///  类型
    ///</summary>
    public ClassifyEnum Stype { get; set; }

    /// <summary>
    ///  归属
    ///</summary>
    public string Belonging { get; set; }

    /// <summary>
    /// 父ID
    ///</summary>
    public long Pid { get; set; }

    /// <summary>
    /// 部门ID
    ///</summary>
    public decimal DepartId { get; set; }

    /// <summary>
    /// 是否启用
    ///</summary>
    public IsEnableEnum IsEnable { get; set; }

    /// <summary>
    ///  描述
    ///</summary>
    public string Describe { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Num { get; set; }
}
/// <summary>
/// 归属分类 修改参数
/// </summary>
public class UpdateInsClassifyInputDto: AddInsClassifyInputDto
{ 
    /// <summary>
    /// 主键ID
    /// </summary>
    public long Id { get; set; }
}
