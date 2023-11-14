
namespace JWPJ.Service;

public interface ISysCacheService: ITransient
{
    /// <summary>
    /// 获取缓存键名集合
    /// </summary>
    /// <returns></returns>
    List<string> GetKeyList();

    /// <summary>
    /// 增加缓存
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    void Set(string key, object value);

    /// <summary>
    /// 增加缓存并设置过期时间
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expire"></param>
    /// <returns></returns>
    public void Set(string key, object value, TimeSpan expire);

    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    T Get<T>(string key);

    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    IList<T> GetList<T>(string key);

    /// <summary>
    /// 删除缓存
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    void Remove(string key);

    /// <summary>
    /// 检查缓存是否存在
    /// </summary>
    /// <param name="key">键</param>
    /// <returns></returns>
    public bool ExistKey(string key);

    /// <summary>
    /// 根据键名前缀删除缓存
    /// </summary>
    /// <param name="prefixKey">键名前缀</param>
    /// <returns></returns>
    int RemoveByPrefixKey(string prefixKey);

    /// <summary>
    /// 获取缓存值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
     dynamic GetValue(string key);
    
}
