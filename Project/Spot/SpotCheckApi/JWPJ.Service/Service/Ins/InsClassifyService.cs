
namespace JWPJ.Service;

/// <summary>
/// 归属分类
/// </summary>
public class InsClassifyService : SqlSugarRepository<InsClassify>, IInsClassifyService
{
    private readonly ILogger<InsClassifyService> _logger;
    private readonly SqlSugarRepository<InsClassify> _repository;
    private readonly ISqlSugarClient _db;
    public InsClassifyService(ILogger<InsClassifyService> logger, SqlSugarRepository<InsClassify> repository, ISqlSugarClient db)
    {
        _logger = logger;
        _repository = repository;
        _db = db;
    }
    /// <summary>
    /// 归属分类 分页查询
    /// </summary>
    /// <returns></returns>
    public async Task<PageResult<InsClassify>> GetInsClassifyPageList(InsClassifyInputDto param)
    {
        Expressionable<InsClassify> whereLambda = Expressionable.Create<InsClassify>();
        if (!string.IsNullOrWhiteSpace(param.Code))
        {
            whereLambda.And((InsClassify x) => x.Code.Contains(param.Code));
        }
        if (!string.IsNullOrWhiteSpace(param.Name))
        {
            whereLambda.And((InsClassify x) => x.Name.Contains(param.Name));
        }
        PageResult<InsClassify> list = await _repository.GetPageListAsync(whereLambda.ToExpression(), param.PageIndex, param.PageSize, x => x.Num, OrderByType.Asc);
        return list;
    }

    /// <summary>
    /// 归属分类 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task AddInsClassify(AddInsClassifyInputDto param)
    {
        if (string.IsNullOrWhiteSpace(param.Name))
            throw Oops.Oh(ErrorCodeEnum.D3002);
        bool isExists = await _repository.IsExistsAsync(x => x.Name == param.Name);
        if (isExists)
            throw Oops.Oh(ErrorCodeEnum.D3001);

        if (param.Num == null)
        {
            int num = await _repository.GetMaxAsync(x => x.Num);
            param.Num = num + 1;
        }
        InsClassify model = new InsClassify();
        model.Code = Utils.RadomGuid();
        model.Name = param.Name;
        model.Describe = param.Describe;
        model.Num = Convert.ToInt32(param.Num);
        await _repository.AddAsync(model);
    }

    /// <summary>
    /// 归属分类 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task UpdateInsClassify(UpdateInsClassifyInputDto param)
    {
        if (param.Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);
        
        if (string.IsNullOrWhiteSpace(param.Name))
            throw Oops.Oh(ErrorCodeEnum.D3002);

        
        if (param.Num == null)
            throw Oops.Oh(ErrorCodeEnum.D3007);
        
        InsClassify model =await _repository.GetModelAsync(x=>x.Id==param.Id);
        model.Name = param.Name;
        model.Describe = param.Describe;
        model.Num = Convert.ToInt32(param.Num);
        await _repository.UpdateAsync(model);
    }

    /// <summary>
    /// 归属分类 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    public async Task DelInsClassify(long Id)
    {

        if (Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);

        await _repository.UpdateAsync(x => x.Id == Id, it => new InsClassify { IsPhantom = 1 });
    }
}
