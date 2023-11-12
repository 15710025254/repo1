
namespace JWPJ.Common;

public class Utils
{
    /// <summary>
    /// 生成GUID
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string RadomGuid()
    {
        return Guid.NewGuid().ToString().ToUpper();
    }
}
