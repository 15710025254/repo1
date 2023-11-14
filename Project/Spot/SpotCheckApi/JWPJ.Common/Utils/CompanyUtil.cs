
namespace JWPJ.Common;

public class CompanyUtil
{
    /// <summary>
    /// 根据公司获取ERP数据库名称
    /// </summary>
    /// <param name="companyNo">公司别</param>
    /// <returns></returns>
    public static string GetDataBaseName(string companyNo)
    {
        companyNo = companyNo == null ? "" : companyNo;
        string dataBaseName = string.Empty;
        switch (companyNo.ToLower())
        {
            case "jw":
                dataBaseName = "JWDZ";
                break;
            case "js":
                dataBaseName = "HFJS";
                break;
            case "bd":
                dataBaseName = "HFBD";
                break;
            default://默认jw
                    //dataBaseName = "JWDZ";
                break;
        }
        return dataBaseName;
    }
}
