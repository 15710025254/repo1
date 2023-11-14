
namespace JWPJ.Core;

public static class SqlSugarSetup
{
    /// <summary>
    /// SqlSugar 上下文初始化
    /// </summary>
    /// <param name="services"></param>
    public static void AddSqlSugar(this IServiceCollection services)
    {
        // 自定义 SqlSugar 雪花ID算法
        SnowFlakeSingle.WorkId = App.GetOptions<SnowIdOptions>().WorkerId;
        StaticConfig.CustomSnowFlakeFunc = () =>
        {
            return YitIdHelper.NextId();
        };

        var dbOptions = App.GetOptions<DbConnectionOptions>();
        dbOptions.ConnectionConfigs.ForEach(SetDbConfig);

        SqlSugarScope sqlSugar = new(dbOptions.ConnectionConfigs.Adapt<List<ConnectionConfig>>(), db =>
        {
            dbOptions.ConnectionConfigs.ForEach(config =>
            {
                var dbProvider = db.GetConnectionScope(config.ConfigId);
                SetDbAop(dbProvider, dbOptions.EnableConsoleSql);
            });
        });


        services.AddSingleton<ISqlSugarClient>(sqlSugar); // 单例注册
        services.AddScoped(typeof(SqlSugarRepository<>)); // 仓储注册
        services.AddUnitOfWork<SqlSugarUnitOfWork>(); // 事务与工作单元注册
    }

    /// <summary>
    /// 配置连接属性
    /// </summary>
    /// <param name="config"></param>
    public static void SetDbConfig(ConnectionConfig config)
    {
        config.InitKeyType = InitKeyType.Attribute;
        config.IsAutoCloseConnection = true;
        config.MoreSettings = new ConnMoreSettings
        {
            IsAutoRemoveDataCache = true,
            IsAutoDeleteQueryFilter = true, // 启用删除查询过滤器
            IsAutoUpdateQueryFilter = true // 启用更新查询过滤器
        };
    }

    /// <summary>
    /// 配置Aop
    /// </summary>
    /// <param name="db"></param>
    public static void SetDbAop(SqlSugarScopeProvider db, bool enableConsoleSql)
    {
        var config = db.CurrentConnectionConfig;

        // 设置超时时间
        db.Ado.CommandTimeOut = 30;

        // 打印SQL语句
        if (enableConsoleSql)
        {
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                var originColor = Console.ForegroundColor;
                if (sql.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                    Console.ForegroundColor = ConsoleColor.Green;
                if (sql.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase) || sql.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase))
                    Console.ForegroundColor = ConsoleColor.Yellow;
                if (sql.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase))
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("【" + DateTime.Now + "——执行SQL】\r\n" + UtilMethods.GetSqlString(config.DbType, sql, pars) + "\r\n");
                Console.ForegroundColor = originColor;
                App.PrintToMiniProfiler("SqlSugar", "Info", sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            };
            db.Aop.OnError = ex =>
            {
                if (ex.Parametres == null) return;
                var originColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                var pars = db.Utilities.SerializeObject(((SugarParameter[])ex.Parametres).ToDictionary(it => it.ParameterName, it => it.Value));
                Console.WriteLine("【" + DateTime.Now + "——错误SQL】\r\n" + UtilMethods.GetSqlString(config.DbType, ex.Sql, (SugarParameter[])ex.Parametres) + "\r\n");
                Console.ForegroundColor = originColor;
                App.PrintToMiniProfiler("SqlSugar", "Error", $"{ex.Message}{Environment.NewLine}{ex.Sql}{pars}{Environment.NewLine}");
            };
            db.Aop.OnLogExecuted = (sql, pars) =>
            {
                // 执行时间超过5秒
                if (db.Ado.SqlExecutionTime.TotalSeconds > 5)
                {
                    var fileName = db.Ado.SqlStackTrace.FirstFileName; // 文件名
                    var fileLine = db.Ado.SqlStackTrace.FirstLine; // 行号
                    var firstMethodName = db.Ado.SqlStackTrace.FirstMethodName; // 方法名
                    var log = $"【所在文件名】：{fileName}\r\n【代码行数】：{fileLine}\r\n【方法名】：{firstMethodName}\r\n" + $"【sql语句】：{UtilMethods.GetSqlString(config.DbType, sql, pars)}";
                    var originColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(log);
                    Console.ForegroundColor = originColor;
                }
            };
        }

        // 数据审计
        db.Aop.DataExecuting = (oldValue, entityInfo) =>
        {

            if (entityInfo.OperationType == DataFilterType.InsertByObject)
            {
                // 主键(long类型)且没有值的---赋值雪花Id
                if (entityInfo.EntityColumnInfo.IsPrimarykey && entityInfo.EntityColumnInfo.PropertyInfo.PropertyType == typeof(decimal))
                {
                    var id = entityInfo.EntityColumnInfo.PropertyInfo.GetValue(entityInfo.EntityValue);
                    if (id == null || (decimal)id == 0)
                        entityInfo.SetValue(Convert.ToDecimal(YitIdHelper.NextId()));
                }
                if (entityInfo.PropertyName == "CreateTime")
                    entityInfo.SetValue(DateTime.Now);
                if (App.User != null)
                {
                    if (entityInfo.PropertyName == "CreateBy")
                    {
                        var createBy = ((dynamic)entityInfo.EntityValue).CreateBy;
                        if (string.IsNullOrWhiteSpace(createBy))
                            entityInfo.SetValue(App.User.FindFirst(ClaimConst.Account)?.Value);
                    }

                    if (entityInfo.PropertyName == "Companyno")
                    {
                        var Companyno = ((dynamic)entityInfo.EntityValue).Companyno;
                        if (string.IsNullOrWhiteSpace(Companyno))
                            entityInfo.SetValue(App.User.FindFirst(ClaimConst.Companyno)?.Value);
                    }
                }
            }
            if (entityInfo.OperationType == DataFilterType.UpdateByObject)
            {
                if (entityInfo.PropertyName == "UpdateTime")
                    entityInfo.SetValue(DateTime.Now);
                if (entityInfo.PropertyName == "UpdateBy")
                    entityInfo.SetValue(App.User?.FindFirst(ClaimConst.Account)?.Value);
            }
        };

        //// 超管时排除各种过滤器
        //if (App.User?.FindFirst(ClaimConst.AccountType)?.Value == ((int)AccountTypeEnum.SuperAdmin).ToString())
        //    return;

        // 配置实体假删除过滤器
        db.QueryFilter.AddTableFilter<IDeletedFilter>(u => u.IsPhantom == 0);
        //// 配置租户过滤器
        //var tenantId = App.User?.FindFirst(ClaimConst.TenantId)?.Value;
        //if (!string.IsNullOrWhiteSpace(tenantId))
        //    db.QueryFilter.AddTableFilter<ITenantIdFilter>(u => u.TenantId == long.Parse(tenantId));

        //// 配置用户机构（数据范围）过滤器
        //SqlSugarFilter.SetOrgEntityFilter(db);
        // 配置自定义过滤器
        //SqlSugarFilter.SetCustomEntityFilter(db);
    }
}
