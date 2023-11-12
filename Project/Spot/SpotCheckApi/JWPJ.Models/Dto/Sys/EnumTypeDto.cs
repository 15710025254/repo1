
namespace JWPJ.Models;

/// <summary>
/// 枚举类型输出参数
/// </summary>
public class EnumTypeOutput
{
    /// <summary>
    /// 枚举类型描述
    /// </summary>
    public string TypeDescribe { get; set; }

    /// <summary>
    /// 枚举类型名称
    /// </summary>
    public string TypeName { get; set; }

    /// <summary>
    /// 枚举类型备注
    /// </summary>
    public string TypeRemark { get; set; }
}

/// <summary>
/// 枚举输入参数
/// </summary>
public class EnumInput
{
    /// <summary>
    /// 枚举类型名称
    /// </summary>
    /// <example>AccountTypeEnum</example>
    [Required(ErrorMessage = "枚举类型不能为空")]
    public string EnumName { get; set; }
}

public class QueryEnumDataInput
{
    /// <summary>
    /// 实体名称
    /// </summary>
    /// <example>SysUser</example>
    [Required(ErrorMessage = "实体名称不能为空")]
    public string EntityName { get; set; }

    /// <summary>
    /// 字段名称
    /// </summary>
    /// <example>AccountType</example>
    [Required(ErrorMessage = "字段名称不能为空")]
    public string FieldName { get; set; }
}