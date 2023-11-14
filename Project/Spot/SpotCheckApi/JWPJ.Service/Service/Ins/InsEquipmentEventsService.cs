
using Mapster;

namespace JWPJ.Service;

/// <summary>
/// 设备事件
/// </summary>
public class InsEquipmentEventsService : SqlSugarRepository<InsEquipmentEvents>, IInsEquipmentEventsService
{
    private readonly ILogger<InsEquipmentEventsService> _logger;
    private readonly SqlSugarRepository<InsEquipmentEvents> _repository;
    private readonly ISqlSugarClient _db;
    public InsEquipmentEventsService(ILogger<InsEquipmentEventsService> logger, SqlSugarRepository<InsEquipmentEvents> repository, ISqlSugarClient db)
    {
        _logger = logger;
        _repository = repository;
        _db = db;
    }

    /// <summary>
    ///  设备事件 分页查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public async Task<PageResult<InsEquipmentEventsOutputDto>> GetInsEquipmentEventsPageList(InsEquipmentEventsInputDto param)
    {
        PageResult<InsEquipmentEventsOutputDto> list = await _repository.AsQueryable().Includes(x => x.EquipmentInfo)
            .Includes(x => x.EquipmentEventsCate)
            .WhereIF(!string.IsNullOrEmpty(param.EventNumber), x => x.EventNumber.Contains(param.EventNumber))
            .WhereIF(!string.IsNullOrEmpty(param.EquipmentCode), x => x.EquipmentInfo.Code.Contains(param.EquipmentCode))
            .WhereIF(!string.IsNullOrEmpty(param.EquipmentName), x => x.EquipmentInfo.Name.Contains(param.EquipmentName))
            .WhereIF(param.InsEquipmentEventsCateId != null, x => x.EventsCateId == param.InsEquipmentEventsCateId)
            .WhereIF(param.IsChangeValue != null, x => x.IsChangeValue == param.IsChangeValue)
            .Select(x => new InsEquipmentEventsOutputDto
            {
                Id = x.Id,
                EventNumber = x.EventNumber,
                InsEquipmentInfId = x.InsEquipmentInfId,
                EquipmentCode = x.EquipmentInfo.Code,
                EquipmentName = x.EquipmentInfo.Name,
                EventsCateId = x.EventsCateId,
                EquipmentEventsCate = x.EquipmentEventsCate.Name,
                Spend = x.Spend,
                IsChangeValue = x.IsChangeValue,
                VariableValue = x.VariableValue,
                Cost = x.Cost,
                ValueAfterChange = x.ValueAfterChange,
                CurDate = x.CurDate,
                Describe = x.Describe,
                CreateBy = x.CreateBy,
                CreateTime = x.CreateTime
            }).ToPageAsync(param.PageIndex, param.PageSize);
        return list;
    }

    /// <summary>
    /// 设备事件 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task AddInsEquipmentEvents(AddInsEquipmentEventsInputDto param)
    {
        InsEquipmentEvents model = param.Adapt<InsEquipmentEvents>();
        model.EventNumber = Utils.RadomGuid();
        await _repository.AddAsync(model);
    }

    /// <summary>
    /// 设备事件 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task UpdateInsEquipmentEvents(UpdateInsEquipmentEventsInputDto param)
    {
        if (param.Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);

        InsEquipmentEvents model = param.Adapt<InsEquipmentEvents>();
        await _repository.UpdateAsync(model);
    }

    /// <summary>
    /// 设备事件 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    public async Task DelInsEquipmentEvents(long Id)
    {
        if (Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);

        await _repository.UpdateAsync(x => x.Id == Id, it => new InsEquipmentEvents { IsPhantom = 1 });
    }

}
