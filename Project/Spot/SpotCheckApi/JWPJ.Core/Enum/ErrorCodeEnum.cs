
namespace JWPJ.Core;

[ErrorCodeType]
[Description("系统错误码")]
public enum ErrorCodeEnum
{
    /// <summary>
    /// 用户已存在
    /// </summary>
    [ErrorCodeItemMetadata("用户已存在")]
    D0008,
    /// <summary>
    /// 账号不存在
    /// </summary>
    [ErrorCodeItemMetadata("账号不存在")]
    D0009,
    /// <summary>
    /// 账号已存在
    /// </summary>
    [ErrorCodeItemMetadata("账号已存在")]
    D0010,
    /// <summary>
    /// 密码不正确
    /// </summary>
    [ErrorCodeItemMetadata("密码不正确")]
    D1000,
    /// <summary>
    /// 非法操作，未登录
    /// </summary>
    [ErrorCodeItemMetadata("非法操作，未登录")]
    D1011,
    /// <summary>
    /// 该类型不是枚举类型
    /// </summary>
    [ErrorCodeItemMetadata("该类型不是枚举类型")]
    D2001,
    /// <summary>
    /// 该实体不存在
    /// </summary>
    [ErrorCodeItemMetadata("该实体不存在")]
    D2002,
    /// <summary>
    /// 名称已存在
    /// </summary>
    [ErrorCodeItemMetadata("名称已存在")]
    D3001,
    /// <summary>
    /// 名称不能为空
    /// </summary>
    [ErrorCodeItemMetadata("名称不能为空")]
    D3002,
    /// <summary>
    /// 添加失败
    /// </summary>
    [ErrorCodeItemMetadata("添加失败")]
    D3003,
    /// <summary>
    /// ID不能为空
    /// </summary>
    [ErrorCodeItemMetadata("ID不能为空")]
    D3004,
    /// <summary>
    /// 删除失败
    /// </summary>
    [ErrorCodeItemMetadata("删除失败")]
    D3005,
    /// <summary>
    /// 更新失败
    /// </summary>
    [ErrorCodeItemMetadata("更新失败")]
    D3006,
    /// <summary>
    /// 排序字段不能为空
    /// </summary>
    [ErrorCodeItemMetadata("排序字段不能为空")]
    D3007,
    /// <summary>
    /// 项目选项不能为空
    /// </summary>
    [ErrorCodeItemMetadata("项目选项不能为空")]
    D3008,
}