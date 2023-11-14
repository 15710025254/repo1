
namespace JWPJ.Core;

/// <summary>
/// SqlSugar查询拓展方法
/// </summary>
public static class QueryableExtension
{
    /// <summary>
    /// 读取分页列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="isOrderBy"></param>
    /// <returns></returns>
    public static async Task<PageResult<T>> ToPageAsync<T>(this ISugarQueryable<T> query,
        int pageIndex,
        int pageSize,
        bool isOrderBy = false)
    {
        RefAsync<int> totalCount = 0;
        var page = new PageResult<T>();
        page.Items = await query.ToPageListAsync(pageIndex, pageSize, totalCount);
        var totalPage = totalCount != 0 ? (totalCount % pageSize) == 0 ? (totalCount / pageSize) : (totalCount / pageSize) + 1 : 0;
        page.TotalCount = totalCount;
        page.TotalPage = totalPage;
        return page;
    }

    /// <summary>
    /// 读取分页列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="isOrderBy"></param>
    /// <returns></returns>
    public static PageResult<T> ToPage<T>(this ISugarQueryable<T> query,
        int pageIndex,
        int pageSize,
        bool isOrderBy = false)
    {
        var page = new PageResult<T>();
        var totalCount = 0;
        page.Items = query.ToPageList(pageIndex, pageSize, ref totalCount);
        var totalPage = totalCount != 0 ? (totalCount % pageSize) == 0 ? (totalCount / pageSize) : (totalCount / pageSize) + 1 : 0;
        page.TotalCount = totalCount;
        page.TotalPage = totalPage;
        return page;
    }
}