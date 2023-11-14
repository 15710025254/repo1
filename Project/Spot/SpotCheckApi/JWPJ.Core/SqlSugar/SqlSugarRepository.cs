
using Furion.DatabaseAccessor;
using Furion.Logging;

namespace JWPJ.Core;

/// <summary>
/// 仓储基类
/// </summary>
/// <typeparam name="T"></typeparam>
public class SqlSugarRepository<T> : SimpleClient<T> where T : class, new()
{
    public ITenant iTenant = null;//多租户事务
    public SqlSugarRepository(ISqlSugarClient context = null) : base(context)
    {

        iTenant = App.GetRequiredService<ISqlSugarClient>().AsTenant();

        // 若实体贴有多库特性，则返回指定的连接
        if (typeof(T).IsDefined(typeof(TenantAttribute), false))
        {
            base.Context = iTenant.GetConnectionScopeWithAttr<T>();
            return;
        }

        // 获取主库连接配置
        var dbOptions = App.GetOptions<DbConnectionOptions>();
        var mainConnConfig = dbOptions.ConnectionConfigs.First(u => u.ConfigId == dbOptions.MainDB);

        iTenant.AddConnection(mainConnConfig);
        SqlSugarSetup.SetDbConfig(mainConnConfig);
        SqlSugarSetup.SetDbAop(iTenant.GetConnectionScope(mainConnConfig.ConfigId), dbOptions.EnableConsoleSql);

        base.Context = iTenant.GetConnectionScope(mainConnConfig.ConfigId);
    }
    #region 基础业务
    
    #region 添加
    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public async Task<bool> AddAsync(T t)
    {
        try
        {
            int rowsAffect = await Context.Insertable(t).IgnoreColumns(true).ExecuteCommandAsync();
            return rowsAffect > 0;
        }
        catch (Exception ex)
        {
            Log.Error($"新增失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3003);
        }
    }
    /// <summary>
    /// 批量新增
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public async Task<bool> InsertAsync(List<T> t)
    {
        try
        {
            int rowsAffect = await Context.Insertable(t).ExecuteCommandAsync();
            return rowsAffect > 0;
        }
        catch (Exception ex)
        {
            Log.Error($"批量新增失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3017);
        }
    }
    /// <summary>
    /// 插入设置列数据
    /// </summary>
    /// <param name="parm"></param>
    /// <param name="iClumns"></param>
    /// <param name="ignoreNull"></param>
    /// <returns></returns>
    public async Task<bool> InsertAsync(T parm, Expression<Func<T, object>> iClumns = null, bool ignoreNull = true)
    {
        try
        {
            int rowsAffect = await Context.Insertable(parm).InsertColumns(iClumns).IgnoreColumns(ignoreNullColumn: ignoreNull).ExecuteCommandAsync();
            return rowsAffect > 0;
        }
        catch (Exception ex)
        {
            Log.Error($"插入设置列数据失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3018);
        }
    }
    #endregion

    #region 修改
    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="ignoreNullColumns"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(T entity, bool ignoreNullColumns = false)
    {
        try
        {
            int rowsAffect = await Context.Updateable(entity).IgnoreColumns(ignoreNullColumns).ExecuteCommandAsync();
            return rowsAffect >= 0;
        }
        catch (Exception ex)
        {
            Log.Error($"更新失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3006);
        }
    }
    /// <summary>
    /// 根据实体类更新指定列 eg：Update(dept, it => new { it.Status });只更新Status列，条件是包含
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="expression"></param>
    /// <param name="ignoreAllNull"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(T entity, Expression<Func<T, object>> expression, bool ignoreAllNull = false)
    {
        try
        {
            int rowsAffect = await Context.Updateable(entity).UpdateColumns(expression).IgnoreColumns(ignoreAllNull).ExecuteCommandAsync();
            return rowsAffect >= 0;
        }
        catch (Exception ex)
        {
            Log.Error($"根据实体类更新指定列失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3006);
        }
    }
    /// <summary>
    /// 根据实体类更新指定列 eg：Update(dept, it => new { it.Status }, f => depts.Contains(f.DeptId));只更新Status列，条件是包含
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="expression"></param>
    /// <param name="where"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(T entity, Expression<Func<T, object>> expression, Expression<Func<T, bool>> where)
    {
        try
        {
            int rowsAffect = await Context.Updateable(entity).UpdateColumns(expression).Where(where).ExecuteCommandAsync();
            return rowsAffect >= 0;
        }
        catch (Exception ex)
        {
            Log.Error($"根据实体类更新指定列失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3006);
        }
    }
    /// <summary>
    /// 更新指定列 eg：Update(w => w.NoticeId == model.NoticeId, it => new SysNotice(){ UpdateTime = DateTime.Now, Title = "通知标题" });
    /// </summary>
    /// <param name="where"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    public async Task<bool> UpdateAsync(Expression<Func<T, bool>> where, Expression<Func<T, T>> columns)
    {
        try
        {
            int rowsAffect = await Context.Updateable<T>().SetColumns(columns).Where(where).RemoveDataCache().ExecuteCommandAsync();
            return rowsAffect >= 0;
        }
        catch (Exception ex)
        {
            Log.Error($"更新指定列失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3006);
        }
    } 
    #endregion
   
    /// <summary>
    /// 事务 eg:var result = UseTran(() =>{SysRoleRepository.UpdateSysRole(sysRole);DeptService.DeleteRoleDeptByRoleId(sysRole.ID);DeptService.InsertRoleDepts(sysRole);});
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public bool UseTran(Action action)
    {
        try
        {
            var result = Context.Ado.UseTran(() => action());
            return result.IsSuccess;
        }
        catch (Exception ex)
        {
            Context.Ado.RollbackTran();
            Log.Error($"事务执行失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3019);
        }
    }

    #region 删除
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">主键id</param>
    /// <param name="IsDelete">是否真删除</param>
    /// <returns></returns>
    public async Task<bool> DeleteByIdAsync(long id, bool IsDelete = false)
    {
        int rowsAffect = 0;
        try
        {
            if (IsDelete)
            {
                rowsAffect = await Context.Deleteable<T>().In(id).ExecuteCommandAsync();
            }
            else
            {
                //假删除 实体属性有isdelete或者isdeleted 请升级到5.0.4.9+，（5.0.4.3存在BUG）
                rowsAffect = await Context.Deleteable<T>().In(id).IsLogic().ExecuteCommandAsync();
            }
            return rowsAffect > 0;
        }
        catch (Exception ex)
        {
            Log.Error($"删除失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3005);
        }
    }
    /// <summary>
    /// 根据查询条件删除
    /// </summary>
    /// <param name="where"></param>
    /// <param name="IsDelete"></param>
    /// <returns></returns>
    public async Task<bool> DeleteByWhereAsync(Expression<Func<T, bool>> where, bool IsDelete = false)
    {
        int rowsAffect = 0;
        try
        {
            if (IsDelete)
            {
                rowsAffect = await Context.Deleteable<T>().Where(where).ExecuteCommandAsync();
            }
            else
            {
                //假删除 实体属性有isdelete或者isdeleted 请升级到5.0.4.9+，（5.0.4.3存在BUG）
                rowsAffect = await Context.Deleteable<T>().Where(where).IsLogic().ExecuteCommandAsync();
            }
            return rowsAffect > 0;
        }
        catch (Exception ex)
        {
            Log.Error($"根据查询条件删除失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3005);
        }
    }
    #endregion

    #region 查询

    /// <summary>
    /// 数据是否存在
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> expression)
    {
        return await Context.Queryable<T>().Where(expression).AnyAsync();
    }

    /// <summary>
    /// 获得一条数据
    /// </summary>
    /// <param name="where">Expression<Func<T, bool>></param>
    /// <returns></returns>
    public async Task<T> GetModelAsync(Expression<Func<T, bool>> where)
    {
        return await Context.Queryable<T>().Where(where).FirstAsync();
    }

    /// <summary>
    /// 获得一条数据 排序
    /// </summary>
    /// <param name="orderFiled">排序字段</param>
    /// <param name="orderEnum">排序方式</param>
    /// <returns></returns>
    public async Task<T> GetModelAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderFiled, OrderByType orderEnum = OrderByType.Desc)
    {
        return await Context.Queryable<T>().Where(expression).OrderByIF(orderEnum == OrderByType.Asc, orderFiled, OrderByType.Asc).OrderByIF(orderEnum == OrderByType.Desc, orderFiled, OrderByType.Desc).FirstAsync();
    }

    /// <summary>
    /// 查询最大值
    /// </summary>
    /// <param name="orderFiled">排序字段</param>
    /// <param name="orderEnum">排序方式</param>
    /// <returns></returns>
    public async Task<int> GetMaxAsync(Expression<Func<T, int>> filed)
    {
        return await Context.Queryable<T>().MaxAsync(filed);
    }


    /// <summary>
    /// 获取所有数据
    /// </summary>
    /// <returns></returns>
    public async Task<List<T>> GetAllAsync()
    {
        return await Context.Queryable<T>().ToListAsync();
    }
    /// <summary>
    /// 根据查询条件获取数据
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public async Task<List<T>> GetListByWhereAsync(Expression<Func<T, bool>> expression)
    {
        return await Context.Queryable<T>().Where(expression).ToListAsync();
    }
    /// <summary>
    /// 根据查询条件获取数据(动态表格拼接查询条件)
    /// </summary>
    /// <param name="conditions"></param>
    /// <returns></returns>
    public async Task<List<T>> GetListByWhereAsync(List<IConditionalModel> conditions)
    {
        return await Context.Queryable<T>().Where(conditions).ToListAsync();
    }
    /// <summary>
    /// 根据查询条件获取数据
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="orderFiled">排序字段</param>
    /// <param name="orderEnum">排序方式</param>
    /// <returns></returns>
    public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderFiled, OrderByType orderEnum = OrderByType.Desc)
    {
        return await Context.Queryable<T>().Where(expression).OrderByIF(orderEnum == OrderByType.Asc, orderFiled, OrderByType.Asc).OrderByIF(orderEnum == OrderByType.Desc, orderFiled, OrderByType.Desc).ToListAsync();
    }
    /// <summary>
    /// 获取所有数据
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="orderFiled">排序字段</param>
    /// <param name="orderEnum">排序方式</param>
    /// <returns></returns>
    public async Task<List<T>> GetListAsync(Expression<Func<T, object>> orderFiled, OrderByType orderEnum = OrderByType.Desc)
    {
        return await Context.Queryable<T>().OrderByIF(orderEnum == OrderByType.Asc, orderFiled, OrderByType.Asc).OrderByIF(orderEnum == OrderByType.Desc, orderFiled, OrderByType.Desc).ToListAsync();
    }
    /// <summary>
    /// 获取分页数据
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public PageResult<T> GetPageList(Expression<Func<T, bool>> expression, int pageIndex, int pageSize)
    {
        int totalCount = 0;
        var result = Context.Queryable<T>().Where(expression).ToPageList(pageIndex, pageSize, ref totalCount);
        var pageResult = new PageResult<T>();
        pageResult.Items = result;
        pageResult.TotalCount = totalCount;
        pageResult.TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
        return pageResult;
    }
    /// <summary>
    /// 获取分页数据
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public async Task<PageResult<T>> GetPageListAsync(Expression<Func<T, bool>> expression, int pageIndex, int pageSize)
    {
        RefAsync<int> totalCount = 0;
        var result = await Context.Queryable<T>().Where(expression).ToPageListAsync(pageIndex, pageSize, totalCount);
        var pageResult = new PageResult<T>();
        pageResult.Items = result;
        pageResult.TotalCount = totalCount;
        pageResult.TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
        return pageResult;
    }
    /// <summary>
    /// 获取分页数据
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="orderFiled"></param>
    /// <param name="orderEnum"></param>
    /// <returns></returns>
    public PageResult<T> GetPageList(Expression<Func<T, bool>> expression, int pageIndex, int pageSize, Expression<Func<T, object>> orderFiled, OrderByType orderEnum = OrderByType.Desc)
    {
        int totalCount = 0;
        var result = Context.Queryable<T>().Where(expression).OrderByIF(orderEnum == OrderByType.Asc, orderFiled, OrderByType.Asc).OrderByIF(orderEnum == OrderByType.Desc, orderFiled, OrderByType.Desc)
            .ToPageList(pageIndex, pageSize, ref totalCount);
        var pageResult = new PageResult<T>();
        pageResult.Items = result;
        pageResult.TotalCount = totalCount;
        pageResult.TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
        return pageResult;
    }
    /// <summary>
    /// 获取分页数据
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="orderFiled"></param>
    /// <param name="orderEnum"></param>
    /// <returns></returns>
    public async Task<PageResult<T>> GetPageListAsync(Expression<Func<T, bool>> expression, int pageIndex, int pageSize, Expression<Func<T, object>> orderFiled, OrderByType orderEnum = OrderByType.Desc)
    {
        RefAsync<int> totalCount = 0;
        var result = await Context.Queryable<T>().Where(expression).OrderByIF(orderEnum == OrderByType.Asc, orderFiled, OrderByType.Asc).OrderByIF(orderEnum == OrderByType.Desc, orderFiled, OrderByType.Desc)
            .ToPageListAsync(pageIndex, pageSize, totalCount);
        var pageResult = new PageResult<T>();
        pageResult.Items = result;
        pageResult.TotalCount = totalCount;
        pageResult.TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
        return pageResult;
    }
    /// <summary>
    /// 获取分页数据
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="orderFiled"></param>
    /// <param name="orderEnum"></param>
    /// <returns></returns>
    public async Task<PageResult<T>> GetOffsetPageListAsync(Expression<Func<T, bool>> expression, int pageIndex, int pageSize, Expression<Func<T, object>> orderFiled, OrderByType orderEnum = OrderByType.Desc)
    {
        RefAsync<int> totalCount = 0;
        var result = await Context.Queryable<T>().Where(expression).OrderByIF(orderEnum == OrderByType.Asc, orderFiled, OrderByType.Asc).OrderByIF(orderEnum == OrderByType.Desc, orderFiled, OrderByType.Desc)
            .ToOffsetPageAsync(pageIndex, pageSize, totalCount);
        var pageResult = new PageResult<T>();
        pageResult.Items = result;
        pageResult.TotalCount = totalCount;
        pageResult.TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
        return pageResult;
    } 
    #endregion
    #endregion

    #region 海量业务高性能
    /// <summary>
    /// 新增（对于海量数据并且性能要高的）
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public async Task<bool> BulkAdd(T t)
    {
        try
        {
            int rowsAffect = await Context.Storageable(t).ToStorage().BulkCopyAsync();
            return rowsAffect > 0;
        }
        catch (Exception ex)
        {
            Log.Error($"新增失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3003);
        }
    }
    /// <summary>
    /// 批量新增（对于海量数据并且性能要高的）
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public async Task<bool> BatchBulkAddAsync(List<T> t)
    {
        try
        {
            int rowsAffect = await Context.Storageable(t).ToStorage().BulkCopyAsync();
            return rowsAffect > 0;
        }
        catch (Exception ex)
        {
            Log.Error($"批量新增失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3017);
        }
    }
    /// <summary>
    /// 更新（对于海量数据并且性能要高的）
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<bool> BulkUpdateAsync(T entity)
    {
        try
        {
            int rowsAffect = await Context.Storageable(entity).ToStorage().BulkUpdateAsync();
            return rowsAffect >= 0;
        }
        catch (Exception ex)
        {
            Log.Error($"更新失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3006);
        }
    }
    /// <summary>
    /// 批量更新（对于海量数据并且性能要高的）
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public async Task<bool> BatchBulkUpdateAsync(List<T> t)
    {
        try
        {
            Context.QueryFilter = new QueryFilterProvider();//清空过滤器 否则会出现Parameter '@IsDelete0' must be defined错误
            int rowsAffect = await Context.Storageable(t).ToStorage().BulkUpdateAsync();
            return rowsAffect >= 0;
        }
        catch (Exception ex)
        {
            Log.Error($"更新失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3006);
        }
    }
    /// <summary>
    /// 批量更新（对于海量数据并且性能要高的）
    /// </summary>
    /// <param name="t"></param>
    /// <param name="updateColumns"></param>
    /// <returns></returns>
    public async Task<bool> BatchBulkUpdateAsync(List<T> t, string[] updateColumns)
    {
        try
        {
            Context.QueryFilter = new QueryFilterProvider();//清空过滤器 否则会出现Parameter '@IsDelete0' must be defined错误
            int rowsAffect = await Context.Storageable(t).ToStorage().BulkUpdateAsync(updateColumns);
            return rowsAffect >= 0;
        }
        catch (Exception ex)
        {
            Log.Error($"更新失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3006);
        }
    }
    #endregion

    #region 存储过程
    /// <summary>
    /// 存储过程
    /// </summary>
    /// <param name="procedureName"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<System.Data.DataTable> ProcedureQueryAsync(string procedureName, object parameters)
    {
        return await Context.Ado.UseStoredProcedure().GetDataTableAsync(procedureName, parameters);
    }
    /// <summary>
    /// 存储过程
    /// </summary>
    /// <param name="procedureName"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<List<T>> ProcedureQueryListAsync(string procedureName, object parameters)
    {
        return await Context.Ado.UseStoredProcedure().SqlQueryAsync<T>(procedureName, parameters);
    }
    #endregion

    #region Fastest
    /// <summary>
    /// 批量新增
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public async Task<bool> BatchFastestkAddAsync(List<T> t)
    {
        try
        {
            int rowsAffect = await Context.Fastest<T>().BulkCopyAsync(t);
            return rowsAffect > 0;
        }
        catch (Exception ex)
        {
            Log.Error($"fastest批量新增失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3017);
        }
    }
    /// <summary>
    /// 批量更新
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public async Task<bool> BatchFastestUpdateAsync(List<T> t)
    {
        try
        {
            Context.QueryFilter = new QueryFilterProvider();//清空过滤器 否则会出现Parameter '@IsDelete0' must be defined错误
            int rowsAffect = await Context.Fastest<T>().BulkUpdateAsync(t);
            return rowsAffect >= 0;
        }
        catch (Exception ex)
        {
            Log.Error($"fastest批量更新失败：{ex.Message}");
            throw Oops.Oh(ErrorCodeEnum.D3020);
        }
    }
    #endregion
}

