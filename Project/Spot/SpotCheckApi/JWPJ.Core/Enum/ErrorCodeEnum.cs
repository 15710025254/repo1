
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
    /// <summary>
    /// 父节点不存在
    /// </summary>
    [ErrorCodeItemMetadata("父节点不存在")]
    D4001,
    /// <summary>
    /// 当前节点Id不能与父节点Id相同
    /// </summary>
    [ErrorCodeItemMetadata("当前节点Id不能与父节点Id相同")]
    D4002,
    /// <summary>
    /// 已有相同区域名称,编码或名称相同
    /// </summary>
    [ErrorCodeItemMetadata("已有相同区域名称,编码或名称相同")]
    D4003,
    /// <summary>
    /// 附件名称不能为空
    /// </summary>
    [ErrorCodeItemMetadata("附件名称不能为空")]
    D3009,
    /// <summary>
    /// 附件后缀名不能为空
    /// </summary>
    [ErrorCodeItemMetadata("附件后缀名不能为空")]
    D3010,
    /// <summary>
    /// 文件不存在
    /// </summary>
    [ErrorCodeItemMetadata("文件不存在")]
    D3011,
    /// <summary>
    /// 不允许的文件类型
    /// </summary>
    [ErrorCodeItemMetadata("不允许的文件类型")]
    D3012,
    /// <summary>
    /// 文件超过允许大小
    /// </summary>
    [ErrorCodeItemMetadata("文件超过允许大小")]
    D3013,
    /// <summary>
    /// 文件后缀错误
    /// </summary>
    [ErrorCodeItemMetadata("文件后缀错误")]
    D3014,
    /// <summary>
    /// 部位为空
    /// </summary>
    [ErrorCodeItemMetadata("部位为空")]
    D3015,
    /// <summary>
    /// 获取部门异常
    /// </summary>
    [ErrorCodeItemMetadata("获取部门异常")]
    D3016,
    /// <summary>
    /// 批量添加失败
    /// </summary>
    [ErrorCodeItemMetadata("批量添加失败")]
    D3017,
    /// <summary>
    /// 插入设置列数据失败
    /// </summary>
    [ErrorCodeItemMetadata("插入设置列数据失败")]
    D3018,
    /// <summary>
    /// 事务执行失败
    /// </summary>
    [ErrorCodeItemMetadata("事务执行失败")]
    D3019,
    /// <summary>
    /// 批量更新失败
    /// </summary>
    [ErrorCodeItemMetadata("批量更新失败")]
    D3020,

}