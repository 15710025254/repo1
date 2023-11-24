
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace JWPJ.Service;

/// <summary>
/// 设备类别
/// </summary>
public class InsEquipmentCateService : SqlSugarRepository<InsEquipmentCate>, IInsEquipmentCateService
{
    private readonly ILogger<InsEquipmentCateService> _logger;
    private readonly SqlSugarRepository<InsEquipmentCate> _repository;
    private readonly ISqlSugarClient _db;
    public InsEquipmentCateService(ILogger<InsEquipmentCateService> logger, SqlSugarRepository<InsEquipmentCate> repository, ISqlSugarClient db)
    {
        _logger = logger;
        _repository = repository;
        _db= db;
    }

    /// <summary>
    ///  设备类别 分页查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public async Task<PageResult<InsEquipmentCate>> GetInsEquipmentCatePageList(InsEquipmentCateInputDto param)
    {
        Expressionable<InsEquipmentCate> whereLambda = Expressionable.Create<InsEquipmentCate>();
        if (!string.IsNullOrWhiteSpace(param.Code))
        {
            whereLambda.And((InsEquipmentCate x) => x.Code.Contains(param.Code));
        }
        if (!string.IsNullOrWhiteSpace(param.Name))
        {
            whereLambda.And((InsEquipmentCate x) => x.Name.Contains(param.Name));
        }
        PageResult<InsEquipmentCate> list = await _repository.GetPageListAsync(whereLambda.ToExpression(), param.PageIndex, param.PageSize, x => x.Num, OrderByType.Asc);
        return list;
    }

    /// <summary>
    ///  设备类别 查询所有数据
    /// </summary>
    /// <returns></returns>
    public async Task<List<InsEquipmentCate>> GetInsEquipmentCateList(LangTypeEnum? LangType)
    {
        Expressionable<InsEquipmentCate> whereLambda = Expressionable.Create<InsEquipmentCate>();
        if (LangType != null)
        {
            whereLambda.And((InsEquipmentCate x) => x.LangType == LangType);
        }
        List<InsEquipmentCate> list = await _repository.GetListAsync(whereLambda.ToExpression(), x => x.Num, OrderByType.Asc);
        return list;
    }

    /// <summary>
    /// 设备类别 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task AddInsEquipmentCate(AddInsEquipmentCateInputDto param)
    {

        if (string.IsNullOrWhiteSpace(param.Name))
            throw Oops.Oh(ErrorCodeEnum.D3002);

        bool isExists = await _repository.IsExistsAsync(x => x.Name == param.Name);
        if (isExists)
            throw Oops.Oh(ErrorCodeEnum.D3001);
        if (param.Num == 0)
        {
            int num = await _repository.GetMaxAsync(x=>x.Num);
            param.Num = num + 1;
        }
        InsEquipmentCate model = new InsEquipmentCate();
        model.Num = param.Num;
        model.Code = Utils.RadomGuid();
        model.Name = param.Name;
        model.Describe = param.Describe;
        model.LangType = param.LangType;
        await  _repository.AddAsync(model);
    }

    /// <summary>
    /// 设备类别 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task UpdateInsEquipmentCate(UpdateInsEquipmentCateInputDto param)
    {
        if (param.Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);
        if (string.IsNullOrWhiteSpace(param.Name))
            throw Oops.Oh(ErrorCodeEnum.D3002);
        if (param.Num == 0)
            throw Oops.Oh(ErrorCodeEnum.D3007);
        InsEquipmentCate model = _repository.GetById(param.Id);
        model.Name = param.Name;
        model.Describe = param.Describe;
        model.Num = param.Num;
        model.LangType = param.LangType;
        await _repository.UpdateAsync(model);
    }

    /// <summary>
    /// 设备类别 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    public async Task DelInsEquipmentCate(long Id)
    {
        if (Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);

        await _repository.UpdateAsync(x => x.Id == Id, it => new InsEquipmentCate { IsPhantom = 1 });
    }

    /// <summary>
    /// 导出
    /// </summary>
    /// <returns></returns>
    public async Task<List<ExportEquipmentCateDto>> ExportLogEx()
    {
        var logExList = await _repository.AsQueryable()
            .OrderBy(u => u.CreateTime, OrderByType.Desc)
            .Select<ExportEquipmentCateDto>().ToListAsync();

        return logExList;
    }

}

