
namespace JWPJ.Models;


/// <summary>
/// 框架实体基类Id
/// </summary>
public abstract class ModelBaseId
{
    /// <summary>
    /// 雪花Id
    /// </summary>
    [SugarColumn(ColumnName = "Id", ColumnDescription = "主键Id", IsPrimaryKey = true, IsIdentity = false)]
    public virtual decimal Id { get; set; }
}

/// <summary>
/// 框架实体基类
/// </summary>
public class ModelBase: ModelBaseId, IDeletedFilter
{
    /// <summary>
    /// 创建时间
    /// </summary>
    [SugarColumn(ColumnName = "CREATE_TIME", ColumnDescription = "创建时间", IsOnlyIgnoreUpdate = true)]
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [SugarColumn(ColumnName = "UPDATE_TIME", ColumnDescription = "更新时间", IsOnlyIgnoreInsert = true)]
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 创建者
    /// </summary>
    [SugarColumn(ColumnName = "CREATE_BY",ColumnDescription = "创建者", IsOnlyIgnoreUpdate = true)]
    public string CreateBy { get; set; }

    /// <summary>
    /// 修改者
    /// </summary>
    [SugarColumn(ColumnName = "UPDATE_BY", ColumnDescription = "修改者", IsOnlyIgnoreInsert = true)]
    public string UpdateBy { get; set; }

    /// <summary>
    /// 是否删除0否1是
    /// </summary>
    [SugarColumn(ColumnName = "IS_PHANTOM", ColumnDescription = "软删除")]
    public int IsPhantom { get; set; } = 0;

    /// <summary>
    ///  公司别
    ///</summary>
    [SugarColumn(ColumnName = "COMPANYNO", ColumnDescription = "公司代码")]
    public  string Companyno { get; set; }

}


/// <summary>
/// 租户基类实体
/// </summary>
public abstract class ModelTenant : ModelBase
{
    /// <summary>
    /// 租户Id
    /// </summary>
    [SugarColumn(ColumnDescription = "租户Id", IsOnlyIgnoreUpdate = true)]
    public virtual long? TenantId { get; set; }
}