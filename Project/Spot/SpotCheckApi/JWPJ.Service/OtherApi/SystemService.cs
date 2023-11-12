
using Furion;
using JWPJ.Core;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JWPJ.Service;

/// <summary>
///  System的API接口
/// </summary>
public class SystemService
{
    private readonly ApiConfigOptions _apiConfigOptions;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="enumOptions"></param>
    public SystemService(IOptions<ApiConfigOptions> apiConfigOptions)
    {
        _apiConfigOptions = apiConfigOptions.Value;
    }

    /// <summary>
    /// 根据公司别获取部门信息
    /// </summary>
    /// <param name="Companyno">公司别</param>
    public async Task<DepartDto> GetDeparts(string Companyno)
    {
        var apiInfo = _apiConfigOptions.ApiList.Find(x=>x.ApiKey== "SYSAPI");

        string[] strArr = Companyno.Split(',');
        var values = new List<KeyValuePair<string, string>>();
        int counter = 0;
        foreach (string i in strArr)
        {
            values.Add(new KeyValuePair<string, string>("COMPANY_NO[" + counter.ToString() + "]", i.ToString()));
            counter++;
        }
        var obj = await HttpHelper.Instance.PostFromBodyAsync($"{apiInfo.Api}/api/dept/BuildHRDeptTreeJson", values);
        var result = JsonConvert.DeserializeObject<JObject>(obj.Content.ReadAsStringAsync().Result);
        if (result == null)
        {
            throw Oops.Oh();
        }
        return null;
    }
}
