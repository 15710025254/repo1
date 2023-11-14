
using System.Text;

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

    /// <summary>
    /// 生成文件批次号
    /// </summary>
    /// <param name="Length"></param>
    /// <returns></returns>
    public static string RandomFileBatchNo()
    {
        return DateTime.Now.ToString("yyyyMMddHHmmssff");
    }

}
