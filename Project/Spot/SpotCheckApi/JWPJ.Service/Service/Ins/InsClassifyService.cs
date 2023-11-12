
using Microsoft.AspNetCore.Mvc;
using StackExchange.Profiling.Internal;

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
    /// 归属分类 查询
    /// </summary>
    /// <returns></returns>
    public async Task<List<InsClassify>> GetInsClassifyPageList(InsClassifyInputDto param)
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
        var iSugarQueryable = _repository.AsQueryable().OrderBy(u => u.Num);
        //var iSugarQueryable = await _repository.GetListAsync(x=>x.Num,OrderByType.Asc);
        // 条件筛选可能造成无法构造树（列表数据）
        if (!string.IsNullOrWhiteSpace(param.Name) || !string.IsNullOrWhiteSpace(param.Code))
        {
            return await iSugarQueryable.WhereIF(!string.IsNullOrWhiteSpace(param.Name), u => u.Name.Contains(param.Name))
                 .WhereIF(!string.IsNullOrWhiteSpace(param.Code), u => u.Code.Contains(param.Code))
                 .ToListAsync();
        }
        if (param.Id > 0)
        {
            return await iSugarQueryable.ToChildListAsync(u => u.Pid, param.Id, true);
        }
        return await iSugarQueryable.ToTreeAsync(u => u.Children, u => u.Pid, 0);
    }

    /// <summary>
    /// 归属分类 添加
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task<long> AddInsClassify(AddInsClassifyInputDto param)
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

        InsClassify model = new InsClassify();
        model.Code = Utils.RadomGuid();
        model.Name = param.Name;
        model.Stype = param.Stype;
        model.Belonging = param.Belonging;
        model.Pid = param.Pid;
        model.DepartId = param.DepartId;
        model.IsEnable = param.IsEnable;
        model.Describe = param.Describe;
        model.Num = param.Num;
        var classify = await _repository.InsertReturnEntityAsync(model);
        return classify.Id;
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
        if (param.Num == 0)
            throw Oops.Oh(ErrorCodeEnum.D3007);
        if (param.Pid != 0)
        {
            InsClassify pInfo = await _repository.GetFirstAsync(u => u.Id == param.Pid);
            pInfo = pInfo ?? throw Oops.Oh(ErrorCodeEnum.D4001);
        }
        if (param.Id == param.Pid)
            throw Oops.Oh(ErrorCodeEnum.D4002);

        var isExist = await _repository.IsAnyAsync(u => u.Name == param.Name && u.Id != param.Id);
        if (isExist)
            throw Oops.Oh(ErrorCodeEnum.D4003);

        // 父Id不能为自己的子节点
        var childIdList = await GetChildIdListWithSelfById(param.Id);
        if (childIdList.Contains(param.Pid))
            throw Oops.Oh(ErrorCodeEnum.D4002);

        await _repository.AsUpdateable(param.Adapt<InsClassify>()).IgnoreColumns(true).ExecuteCommandAsync();
    }

    /// <summary>
    /// 根据节点Id获取子节点Id集合(包含自己)
    /// </summary>
    /// <param name="pid"></param>
    /// <returns></returns>
    private async Task<List<long>> GetChildIdListWithSelfById(long pid)
    {
        var treeList = await _repository.AsQueryable().ToChildListAsync(u => u.Pid, pid, true);
        return treeList.Select(u => u.Id).ToList();
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

        //await _repository.UpdateAsync(x => x.Id == Id, it => new InsClassify { IsPhantom = 1 });

        var insClassify = await _repository.GetFirstAsync(u => u.Id == Id);
        var treeList = await _repository.AsQueryable().ToChildListAsync(u => u.Pid, Id, true);
        var idList = treeList.Select(u => u.Id).ToList();
        // 级联删除子节点
        await _repository.DeleteAsync(u => idList.Contains(u.Id));
    }
}
