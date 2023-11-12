
namespace JWPJ.Service;

/// <summary>
/// 点检项目模版
/// </summary>
public interface IInsItemsTempService: ITransient
{
    /// <summary>
    /// 点检项目模版 查询列表
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task<PageResult<InsItemsTemp>> GetInsItemsTempList(InsItemsTempInputDto param);

    /// <summary>
    /// 点检项目模版 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task AddInsItemsTemp(AddInsItemsTempInputDto param);

    /// <summary>
    /// 点检项目模版 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task UpdateInsItemsTemp(UpdateInsItemsTempInputDto param);

    /// <summary>
    /// 点检项目模版 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    Task DelInsItemsTemp(long Id);
}
