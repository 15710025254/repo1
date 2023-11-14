
namespace JWPJ.Service;

/// <summary>
/// 点检项目模版
/// </summary>
public class InsItemsTempService: SqlSugarRepository<InsItemsTemp>, IInsItemsTempService
{
    private readonly ILogger<InsItemsTempService> _logger;
    private readonly SqlSugarRepository<InsItemsTemp> _repository;
    private readonly ISqlSugarClient _db;
    public InsItemsTempService(ILogger<InsItemsTempService> logger, SqlSugarRepository<InsItemsTemp> repository, ISqlSugarClient db)
    {
        _logger = logger;
        _repository = repository;
        _db = db;
    }
    /// <summary>
    /// 点检项目模版 分页查询
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task<PageResult<InsItemsTemp>> GetInsItemsTempList(InsItemsTempInputDto param)
    {
        Expressionable<InsItemsTemp> whereLambda = Expressionable.Create<InsItemsTemp>();
        if (!string.IsNullOrWhiteSpace(param.Code))
        {
            whereLambda.And((InsItemsTemp x) => x.Code.Contains(param.Code));
        }
        if (!string.IsNullOrWhiteSpace(param.Name))
        {
            whereLambda.And((InsItemsTemp x) => x.Name.Contains(param.Name));
        }
        if (!string.IsNullOrWhiteSpace(param.Item))
        {
            whereLambda.And((InsItemsTemp x) => x.Item.Contains(param.Item));
        }
        PageResult<InsItemsTemp> list = await _repository.GetPageListAsync(whereLambda.ToExpression(), param.PageIndex, param.PageSize, x => x.CreateTime, OrderByType.Desc);
        return list;
    }

    /// <summary>
    /// 点检项目模版 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task AddInsItemsTemp(AddInsItemsTempInputDto param)
    {
        InsItemsTemp model = new InsItemsTemp();
        model.Code = Utils.RadomGuid();
        model.Name = param.Name;
        model.Item = param.Item;
        await _repository.AddAsync(model);
    }

    /// <summary>
    /// 点检项目模版 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task UpdateInsItemsTemp(UpdateInsItemsTempInputDto param)
    {
        if (string.IsNullOrWhiteSpace(param.Item))
            throw Oops.Oh(ErrorCodeEnum.D3008);
        if (param.Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);
        if (string.IsNullOrWhiteSpace(param.Name))
            throw Oops.Oh(ErrorCodeEnum.D3002);
        InsItemsTemp insItemsTemp = await _repository.GetByIdAsync(param.Id);
        insItemsTemp.Item = param.Item;
        insItemsTemp.Name = param.Name;
        await _repository.UpdateAsync(insItemsTemp);
        
    }

    /// <summary>
    /// 点检项目模版 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    public async Task DelInsItemsTemp(long Id)
    {
        if (Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);
        await _repository.UpdateAsync(x => x.Id == Id, it => new InsItemsTemp { IsPhantom = 1 });
    }
}
