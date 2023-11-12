
namespace JWPJ.Service;

/// <summary>
/// 常量单位
/// </summary>
public class InsUnitService : SqlSugarRepository<InsUnit>, IInsUnitService
{
    private readonly ILogger<InsUnitService> _logger;
    private readonly SqlSugarRepository<InsUnit> _repository;
    private readonly ISqlSugarClient _db;
    public InsUnitService(ILogger<InsUnitService> logger, SqlSugarRepository<InsUnit> repository, ISqlSugarClient db)
    {
        _logger = logger;
        _repository = repository;
        _db = db;
    }

    /// <summary>
    ///  常量单位 分页查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public async Task<PageResult<InsUnit>> GetInsUnitPageList(InsUnitInputDto param)
    {
        Expressionable<InsUnit> whereLambda = Expressionable.Create<InsUnit>();
        if (!string.IsNullOrWhiteSpace(param.Code))
        {
            whereLambda.And((InsUnit x) => x.Code.Contains(param.Code));
        }
        if (!string.IsNullOrWhiteSpace(param.Name))
        {
            whereLambda.And((InsUnit x) => x.Name.Contains(param.Name));
        }
        PageResult<InsUnit> list = await _repository.GetPageListAsync(whereLambda.ToExpression(), param.PageIndex, param.PageSize, x => x.Num, OrderByType.Asc);
        return list;
    }

    /// <summary>
    ///  常量单位 查询所有数据
    /// </summary>
    /// <returns></returns>
    public async Task<List<InsUnit>> GetInsUnitList()
    {
        List<InsUnit> list = await _repository.GetListAsync(x => x.Num, OrderByType.Asc);
        return list;
    }

    /// <summary>
    /// 常量单位 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task AddInsUnit(AddInsUnitInputDto param)
    {
        if (string.IsNullOrWhiteSpace(param.Name))
            throw Oops.Oh(ErrorCodeEnum.D3002);

        bool isExists = await _repository.IsExistsAsync(x => x.Name == param.Name);
        if (isExists)
            throw Oops.Oh(ErrorCodeEnum.D3001);
        if (param.Num == 0)
        {
            int num = await _repository.GetMaxAsync(x => x.Num);
            param.Num = num + 1;
        }
        InsUnit model = new InsUnit();
        model.Num = param.Num;
        model.Code = Utils.RadomGuid();
        model.Name = param.Name;
        model.Describe = param.Describe;
        model.LangType = param.LangType;
        await _repository.AddAsync(model);
    }

    /// <summary>
    /// 常量单位 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task UpdateInsUnit(UpdateInsUnitInputDto param)
    {
        if (param.Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);
        if (string.IsNullOrWhiteSpace(param.Name))
            throw Oops.Oh(ErrorCodeEnum.D3002);
        if (param.Num == 0)
            throw Oops.Oh(ErrorCodeEnum.D3007);
        InsUnit model = _repository.GetById(param.Id);
        model.Name = param.Name;
        model.Describe = param.Describe;
        model.Num = param.Num;
        model.LangType = param.LangType;
        await _repository.UpdateAsync(model);
    }

    /// <summary>
    /// 常量单位 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    public async Task DelInsUnit(long Id)
    {
        if (Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);

        await _repository.UpdateAsync(x => x.Id == Id, it => new InsUnit { IsPhantom = 1 });
    }

}
