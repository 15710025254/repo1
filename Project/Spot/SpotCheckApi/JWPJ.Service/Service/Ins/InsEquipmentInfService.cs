
namespace JWPJ.Service;

/// <summary>
/// 设备信息
/// </summary>
public class InsEquipmentInfService:SqlSugarRepository<InsEquipmentInf>, IInsEquipmentInfService
{
    private readonly ILogger<InsEquipmentInfService> _logger;
    private readonly SqlSugarRepository<InsEquipmentInf> _repository;
    private readonly ISqlSugarClient _db;
    public InsEquipmentInfService(ILogger<InsEquipmentInfService> logger, SqlSugarRepository<InsEquipmentInf> repository, ISqlSugarClient db)
    {
        _logger = logger;
        _repository = repository;
        _db = db;
    }

    ///// <summary>
    /////  设备 分页查询
    ///// </summary>
    ///// <param name="param"></param>
    ///// <returns></returns>
    //public async Task<PageResult<InsEquipmentCate>> GetInsEquipmentPageList(InsEquipmentInputDto param)
    //{
       
    //}
}
