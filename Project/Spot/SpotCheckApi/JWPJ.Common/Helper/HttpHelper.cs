
namespace JWPJ.Common;

public class HttpHelper
{
    public static readonly HttpHelper Instance;
    static HttpHelper()
    {
        Instance = new HttpHelper();
    }

    /// <summary>
    /// Post请求
    /// </summary>
    /// <param name="url">url地址</param>
    /// <param name="keyValuePairs">请求参数</param>
    /// <returns></returns>
    public async Task<HttpResponseMessage> PostFromBodyAsync(string url, List<KeyValuePair<string, string>> keyValuePairs)
    {
        var httpClient = new HttpClient(new HttpClientHandler());
        HttpResponseMessage response = await httpClient.PostAsync(url, new FormUrlEncodedContent(keyValuePairs));
        return response;
    }
}
