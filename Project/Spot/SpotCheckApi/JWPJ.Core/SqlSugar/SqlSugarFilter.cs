
using System.Collections.Concurrent;

namespace JWPJ.Core;

public static class SqlSugarFilter
{
    ///// <summary>
    ///// 配置用户仅本人数据过滤器
    ///// </summary>
    //private static int SetDataScopeFilter(SqlSugarScopeProvider db)
    //{
    //    var maxDataScope = (int)DataScopeEnum.All;

    //    var userId = App.User?.FindFirst(ClaimConst.UserId)?.Value;
    //    if (string.IsNullOrWhiteSpace(userId)) return maxDataScope;

    //    // 获取用户最大数据范围---仅本人数据
    //    maxDataScope = App.GetService<SysCacheService>().Get<int>(CacheConst.KeyRoleMaxDataScope + userId);
    //    if (maxDataScope != (int)DataScopeEnum.Self) return maxDataScope;

    //    // 配置用户数据范围缓存
    //    var cacheKey = $"db:{db.CurrentConnectionConfig.ConfigId}:dataScope:{userId}";
    //    var dataScopeFilter = _cache.Get<ConcurrentDictionary<Type, LambdaExpression>>(cacheKey);
    //    if (dataScopeFilter == null)
    //    {
    //        // 获取业务实体数据表
    //        var entityTypes = App.EffectiveTypes.Where(u => !u.IsInterface && !u.IsAbstract && u.IsClass
    //            && u.IsSubclassOf(typeof(EntityBaseData)));
    //        if (!entityTypes.Any()) return maxDataScope;

    //        dataScopeFilter = new ConcurrentDictionary<Type, LambdaExpression>();
    //        foreach (var entityType in entityTypes)
    //        {
    //            // 排除非当前数据库实体
    //            var tAtt = entityType.GetCustomAttribute<TenantAttribute>();
    //            if ((tAtt != null && db.CurrentConnectionConfig.ConfigId.ToString() != tAtt.configId.ToString()))
    //                continue;

    //            var lambda = DynamicExpressionParser.ParseLambda(new[] {
    //                Expression.Parameter(entityType, "u") }, typeof(bool), $"u.{nameof(EntityBaseData.CreateUserId)}=@0", userId);
    //            db.QueryFilter.AddTableFilter(entityType, lambda);
    //            dataScopeFilter.TryAdd(entityType, lambda);
    //        }
    //        _cache.Add(cacheKey, dataScopeFilter);
    //    }
    //    else
    //    {
    //        foreach (var filter in dataScopeFilter)
    //            db.QueryFilter.AddTableFilter(filter.Key, filter.Value);
    //    }
    //    return maxDataScope;
    //}
}
