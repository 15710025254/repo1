

namespace JWPJ.Models;

/// <summary>
/// 系统用户表
/// </summary>
[SugarTable(null, "系统用户表")]
public class SysUser : ModelTenant
{
    /// <summary>
    /// 账号
    /// </summary>
    [SugarColumn(ColumnDescription = "账号", Length = 32)]
    [Required, MaxLength(32)]
    public string Account { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [SugarColumn(ColumnDescription = "密码", Length = 512)]
    [MaxLength(512)]
    [JsonIgnore]
    public string Password { get; set; }

    /// <summary>
    /// 真实姓名
    /// </summary>
    [SugarColumn(ColumnDescription = "真实姓名", Length = 32)]
    [MaxLength(32)]
    public string RealName { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [SugarColumn(ColumnDescription = "昵称", Length = 32)]
    [MaxLength(32)]
    public string NickName { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    [SugarColumn(ColumnDescription = "头像", Length = 512)]
    [MaxLength(512)]
    public string Avatar { get; set; }

    /// <summary>
    /// 性别-男_1、女_2
    /// </summary>
    [SugarColumn(ColumnDescription = "性别")]
    public GenderEnum Sex { get; set; } = GenderEnum.Male;
    //public int Sex { get; set; }
    /// <summary>
    /// 年龄
    /// </summary>
    [SugarColumn(ColumnDescription = "年龄")]
    public int Age { get; set; }

    ///// <summary>
    ///// 出生日期
    ///// </summary>
    //[SugarColumn(ColumnDescription = "出生日期")]
    //public DateTime? Birthday { get; set; }

    ///// <summary>
    ///// 民族
    ///// </summary>
    //[SugarColumn(ColumnDescription = "民族", Length = 32)]
    //[MaxLength(32)]
    //public string Nation { get; set; }

    ///// <summary>
    ///// 手机号码
    ///// </summary>
    //[SugarColumn(ColumnDescription = "手机号码", Length = 16)]
    //[MaxLength(16)]
    //public string Phone { get; set; }

    ///// <summary>
    ///// 证件类型
    ///// </summary>
    //[SugarColumn(ColumnDescription = "证件类型")]
    //public int CardType { get; set; }//CardTypeEnum

    ///// <summary>
    ///// 身份证号
    ///// </summary>
    //[SugarColumn(ColumnDescription = "身份证号", Length = 32)]
    //[MaxLength(32)]
    //public string IdCardNum { get; set; }

    ///// <summary>
    ///// 邮箱
    ///// </summary>
    //[SugarColumn(ColumnDescription = "邮箱", Length = 64)]
    //[MaxLength(64)]
    //public string Email { get; set; }

    ///// <summary>
    ///// 地址
    ///// </summary>
    //[SugarColumn(ColumnDescription = "地址", Length = 256)]
    //[MaxLength(256)]
    //public string Address { get; set; }

    ///// <summary>
    ///// 文化程度
    ///// </summary>
    //[SugarColumn(ColumnDescription = "文化程度")]
    //public int CultureLevel { get; set; }//CultureLevelEnum

    ///// <summary>
    ///// 政治面貌
    ///// </summary>
    //[SugarColumn(ColumnDescription = "政治面貌", Length = 16)]
    //[MaxLength(16)]
    //public string PoliticalOutlook { get; set; }

    ///// <summary>
    ///// 毕业院校
    ///// </summary>COLLEGE
    //[SugarColumn(ColumnDescription = "毕业院校", Length = 128)]
    //[MaxLength(128)]
    //public string College { get; set; }

    ///// <summary>
    ///// 办公电话
    ///// </summary>
    //[SugarColumn(ColumnDescription = "办公电话", Length = 16)]
    //[MaxLength(16)]
    //public string OfficePhone { get; set; }

    ///// <summary>
    ///// 紧急联系人
    ///// </summary>
    //[SugarColumn(ColumnDescription = "紧急联系人", Length = 32)]
    //[MaxLength(32)]
    //public string EmergencyContact { get; set; }

    ///// <summary>
    ///// 紧急联系人电话
    ///// </summary>
    //[SugarColumn(ColumnDescription = "紧急联系人电话", Length = 16)]
    //[MaxLength(16)]
    //public string EmergencyPhone { get; set; }

    ///// <summary>
    ///// 紧急联系人地址
    ///// </summary>
    //[SugarColumn(ColumnDescription = "紧急联系人地址", Length = 256)]
    //[MaxLength(256)]
    //public string EmergencyAddress { get; set; }

    ///// <summary>
    ///// 个人简介
    ///// </summary>
    //[SugarColumn(ColumnDescription = "个人简介", Length = 512)]
    //[MaxLength(512)]
    //public string Introduction { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [SugarColumn(ColumnDescription = "排序")]
    public int OrderNo { get; set; } = 100;

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态")]
    //public StatusEnum Status { get; set; } = StatusEnum.Enable;
    public int Status { get; set; }
    ///// <summary>
    ///// 备注
    ///// </summary>
    //[SugarColumn(ColumnDescription = "备注", Length = 256)]
    //[MaxLength(256)]
    //public string Remark { get; set; }

    /// <summary>
    /// 账号类型
    /// </summary>
    [SugarColumn(ColumnDescription = "账号类型")]
    //public AccountTypeEnum AccountType { get; set; } = AccountTypeEnum.NormalUser;
    public int AccountType { get; set; }


    /// <summary>
    /// 直属机构Id
    /// </summary>
    [SugarColumn(ColumnDescription = "直属机构Id")]
    public long OrgId { get; set; }

    ///// <summary>
    ///// 工号
    ///// </summary>
    //[SugarColumn(ColumnDescription = "工号", Length = 32)]
    //[MaxLength(32)]
    //public string JobNum { get; set; }

    ///// <summary>
    ///// 入职日期
    ///// </summary>
    //[SugarColumn(ColumnDescription = "入职日期")]
    //public DateTime? JoinDate { get; set; }

    ///// <summary>
    ///// 最新登录Ip
    ///// </summary>
    //[SugarColumn(ColumnDescription = "最新登录Ip", Length = 256)]
    //[MaxLength(256)]
    //public string LastLoginIp { get; set; }

    ///// <summary>
    ///// 最新登录地点
    ///// </summary>
    //[SugarColumn(ColumnDescription = "最新登录地点", Length = 128)]
    //[MaxLength(128)]
    //public string LastLoginAddress { get; set; }

    ///// <summary>
    ///// 最新登录时间
    ///// </summary>
    //[SugarColumn(ColumnDescription = "最新登录时间")]
    //public DateTime? LastLoginTime { get; set; }

    ///// <summary>
    ///// 最新登录设备
    ///// </summary>
    //[SugarColumn(ColumnDescription = "最新登录设备", Length = 128)]
    //[MaxLength(128)]
    //public string LastLoginDevice { get; set; }

}