
namespace JWPJ.Models;

/// <summary>
/// 用户登录参数
/// </summary>
public class LoginInputDto
{
    /// <summary>
    /// 账号
    /// </summary>
    /// <example>admin</example>
    [Required(ErrorMessage = "账号不能为空"), MinLength(2, ErrorMessage = "账号不能少于2个字符")]
    public string Account { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    /// <example>123456</example>
    [Required(ErrorMessage = "密码不能为空"), MinLength(3, ErrorMessage = "密码不能少于3个字符")]
    public string Password { get; set; }

    /// <summary>
    /// 验证码Id
    /// </summary>
    public long CodeId { get; set; }

    /// <summary>
    /// 验证码
    /// </summary>
    public string Code { get; set; }
}

public class PageUserInput : QueryCriteria
{
    /// <summary>
    /// 账号
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string RealName { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 查询时所选机构Id
    /// </summary>
    public long OrgId { get; set; }
}

public class AddUserInput:SysUser
{
    ///// <summary>
    ///// 账号
    ///// </summary>
    //[Required(ErrorMessage = "账号不能为空")]
    //public string Account { get; set; }

    ///// <summary>
    ///// 真实姓名
    ///// </summary>
    //[Required(ErrorMessage = "真实姓名不能为空")]
    //public string RealName { get; set; }

    ///// <summary>
    ///// 密码
    ///// </summary>
    //public string Password { get; set; }

    ///// <summary>
    ///// 昵称
    ///// </summary>
    //public string NickName { get; set; }

    ///// <summary>
    ///// 性别-男_1、女_2
    ///// </summary>
    //public GenderEnum Sex { get; set; } = GenderEnum.Male;
    ///// <summary>
    ///// 年龄
    ///// </summary>
    //public int Age { get; set; }

    ///// <summary>
    ///// 证件类型
    ///// </summary>
    //[SugarColumn(ColumnDescription = "证件类型")]
    //public CardTypeEnum CardType { get; set; }

    ///// <summary>
    ///// 文化程度
    ///// </summary>
    //[SugarColumn(ColumnDescription = "文化程度")]
    //public CultureLevelEnum CultureLevel { get; set; }

    ///// <summary>
    ///// 备注
    ///// </summary>
    //[SugarColumn(ColumnDescription = "备注", Length = 256)]
    //[MaxLength(256)]
    //public string Remark { get; set; }

    ///// <summary>
    ///// 账号类型
    ///// </summary>
    //[SugarColumn(ColumnDescription = "账号类型")]
    //public AccountTypeEnum AccountType { get; set; } = AccountTypeEnum.NormalUser;
}

public class UpdateUserInput : SysUser
{
}
