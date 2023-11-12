
Serve.Run(RunOptions.Default.AddWebComponent<WebComponent>());

/// <summary>
/// 
/// </summary>
public class WebComponent : IWebComponent
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="componentContext"></param>
    public void Load(WebApplicationBuilder builder, ComponentContext componentContext)
    {
        // ������־����
        builder.Logging.AddFilter((provider, category, logLevel) =>
        {
            return !new[] { "Microsoft.Hosting", "Microsoft.AspNetCore" }.Any(u => category.StartsWith(u)) && logLevel >= LogLevel.Information;
        });

        // ���ýӿڳ�ʱʱ����ϴ���С
        builder.Configuration.Get<WebHostBuilder>().ConfigureKestrel(u =>
        {
            u.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);
            u.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(30);
            u.Limits.MaxRequestBodySize = null;
        });
    }
}

//namespace JWPJWebApi;

///// <summary>
///// 
///// </summary>
//public class Program
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="args"></param>
//    public static void Main(string[] args)
//    {
//        CreateHostBuilder(args).Build().Run();
//    }
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="args"></param>
//    /// <returns></returns>
//    public static IHostBuilder CreateHostBuilder(string[] args)
//    {
//        return Host.CreateDefaultBuilder(args)
//            .ConfigureWebHostDefaults(webBuilder =>
//            {
//                webBuilder.UseStartup<Startup>();
//            });
//    }
//}
