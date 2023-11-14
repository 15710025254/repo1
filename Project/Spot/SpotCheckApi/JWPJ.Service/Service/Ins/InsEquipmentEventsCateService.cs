
namespace JWPJ.Service;

/// <summary>
/// 设备事件类型
/// </summary>
public class InsEquipmentEventsCateService : SqlSugarRepository<InsEquipmentEventsCate>, IInsEquipmentEventsCateService
{
    private readonly ILogger<InsEquipmentEventsCateService> _logger;
    private readonly SqlSugarRepository<InsEquipmentEventsCate> _repository;
    private readonly ISqlSugarClient _db;
    public InsEquipmentEventsCateService(ILogger<InsEquipmentEventsCateService> logger, SqlSugarRepository<InsEquipmentEventsCate> repository, ISqlSugarClient db)
    {
        _logger = logger;
        _repository = repository;
        _db = db;
    }

    /// <summary>
    ///  设备事件类型 分页查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public async Task<PageResult<InsEquipmentEventsCate>> GetInsEquipmentEventsCatePageList(InsEquipmentEventsCateInputDto param)
    {
        Expressionable<InsEquipmentEventsCate> whereLambda = Expressionable.Create<InsEquipmentEventsCate>();
        if (!string.IsNullOrWhiteSpace(param.Code))
        {
            whereLambda.And((InsEquipmentEventsCate x) => x.Code.Contains(param.Code));
        }
        if (!string.IsNullOrWhiteSpace(param.Name))
        {
            whereLambda.And((InsEquipmentEventsCate x) => x.Name.Contains(param.Name));
        }
        PageResult<InsEquipmentEventsCate> list = await _repository.GetPageListAsync(whereLambda.ToExpression(), param.PageIndex, param.PageSize, x => x.Num, OrderByType.Asc);
        return list;
    }

    /// <summary>
    ///  设备事件类型 查询所有数据
    /// </summary>
    /// <returns></returns>
    public async Task<List<InsEquipmentEventsCate>> GetInsEquipmentEventsCateList(LangTypeEnum? LangType)
    {
        Expressionable<InsEquipmentEventsCate> whereLambda = Expressionable.Create<InsEquipmentEventsCate>();
        if (LangType != null)
        {
            whereLambda.And((InsEquipmentEventsCate x) => x.LangType == LangType);
        }
        List<InsEquipmentEventsCate> list = await _repository.GetListAsync(whereLambda.ToExpression(), x => x.Num, OrderByType.Asc);
        return list;
    }

    /// <summary>
    /// 设备事件类型 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task AddInsEquipmentEventsCate(AddInsEquipmentEventsCateInputDto param)
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
        InsEquipmentEventsCate model = new InsEquipmentEventsCate();
        model.Num = param.Num;
        model.Code = Utils.RadomGuid();
        model.Name = param.Name;
        model.Describe = param.Describe;
        model.LangType = param.LangType;
        await _repository.AddAsync(model);
    }

    /// <summary>
    /// 设备事件类型 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task UpdateInsEquipmentEventsCate(UpdateInsEquipmentEventsCateInputDto param)
    {
        if (param.Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);
        if (string.IsNullOrWhiteSpace(param.Name))
            throw Oops.Oh(ErrorCodeEnum.D3002);
        if (param.Num == 0)
            throw Oops.Oh(ErrorCodeEnum.D3007);
        InsEquipmentEventsCate model = _repository.GetById(param.Id);
        model.Name = param.Name;
        model.Describe = param.Describe;
        model.Num = param.Num;
        model.LangType = param.LangType;
        await _repository.UpdateAsync(model);
    }

    /// <summary>
    /// 设备事件类型 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    public async Task DelInsEquipmentEventsCate(long Id)
    {
        if (Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);

        await _repository.UpdateAsync(x => x.Id == Id, it => new InsEquipmentEventsCate { IsPhantom = 1 });
    }

}
