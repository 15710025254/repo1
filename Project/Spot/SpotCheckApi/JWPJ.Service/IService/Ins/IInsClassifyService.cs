
namespace JWPJ.Service;
/// <summary>
/// 归属分类
/// </summary>
public interface IInsClassifyService:ITransient
{
    /// <summary>
    /// 归属分类 分页查询
    /// </summary>
    /// <returns></returns>
    Task<List<InsClassify>> GetInsClassifyList(InsClassifyInputDto param);

    /// <summary>
    /// 归属分类 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task<decimal> AddInsClassify(AddInsClassifyInputDto param);

    /// <summary>
    /// 归属分类 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    Task UpdateInsClassify(UpdateInsClassifyInputDto param);

    /// <summary>
    /// 归属分类 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    Task DelInsClassify(long Id);
}
