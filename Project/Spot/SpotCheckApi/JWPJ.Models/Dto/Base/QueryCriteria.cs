
namespace JWPJ.Models;

/// <summary>
/// 分页查询输入参数
/// </summary>
public class QueryCriteria
{
    /// <summary>
    /// 页码
    /// </summary>
    public int PageIndex { get; set; } = 1;
    /// <summary>
    /// 分页大小
    /// </summary>
    public int PageSize { get; set; } = 10;
    /// <summary>
    /// 开始日期
    /// </summary>
    public DateTime? StartTime { get; set; }
    /// <summary>
    /// 结束日期
    /// </summary>
    public DateTime? EndTime { get; set; }

}
