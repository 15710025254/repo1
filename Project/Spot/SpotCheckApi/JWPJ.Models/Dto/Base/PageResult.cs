
namespace JWPJ.Models;

/// <summary>
/// 分页数据信息
/// </summary>
/// <typeparam name="T"></typeparam>
public class PageResult<T>
{
    /// <summary>
    /// 页总数
    /// </summary>
    public int TotalPage { get; set; }
    /// <summary>
    /// 记录总数
    /// </summary>
    public int TotalCount { get; set; }
    /// <summary>
    /// 记录集合
    /// </summary>
    public List<T> Items { get; set; } = new();
}