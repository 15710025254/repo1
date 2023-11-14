
namespace JWPJ.Service;

/// <summary>
/// 登录系统的的API接口
/// </summary>
public class SystemService
{
    /// <summary>
    /// 根据公司别获取部门信息
    /// </summary>
    /// <param name="Companyno">公司别</param>
    public static async Task<List<DepartDto>> GetDeparts(string Companyno)
    {
        ApiInfo apiInfo = App.GetOptions<ApiConfigOptions>().ApiList.Find(x=>x.ApiKey== "SYSAPI");

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
            throw Oops.Oh(ErrorCodeEnum.D3015);
        }
        if (Convert.ToBoolean(result["success"]))
        {
            return JsonConvert.DeserializeObject<List<DepartDto>>(result["data"].ToString());
        }
        throw Oops.Oh(ErrorCodeEnum.D3016);
    }
}
