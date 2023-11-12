
namespace JWPJWebApi;

/// <summary>
/// 
/// </summary>
public class Startup : AppStartup
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        // 配置选项
        services.AddProjectOptions();
        //注册缓存
        services.AddCache();
        //注册SqlSugar
        services.AddSqlSugar();
        // JWT
        services.AddJwt<JwtHandler>(enableGlobalAuthorize: true);
        //配置跨域
        services.AddCorsAccessor();

        //返回值处理
        services.AddControllersWithViews()
            .AddAppLocalization() // 注册多语言
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss"; // 时间格式化
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; // 忽略循环引用
            }).AddInjectWithUnifyResult<AdminResultProvider>();



        ////设置日志
        //Array.ForEach(new[] { LogLevel.Information, LogLevel.Error }, logLevel =>
        //{
        //    services.AddFileLogging("Logs/{1}-{0:yyyy}-{0:MM}-{0:dd}-{0:HH}.log", options =>
        //    {
        //        options.FileNameRule = fileName => string.Format(fileName, DateTime.UtcNow, logLevel.ToString());
        //        options.WriteFilter = logMsg => logMsg.LogLevel == logLevel;
        //        options.Append = true;
        //        //options.MessageFormat = (logMsg) =>
        //        //{
        //        //    var stringBuilder = new System.Text.StringBuilder();
        //        //    stringBuilder.Append(System.DateTime.Now.ToString("o"));
        //        //    // 其他的。。。自己组装
        //        //    return stringBuilder.ToString();
        //        //};
        //    });
        //});
        // 雪花Id
        YitIdHelper.SetIdGenerator(App.GetOptions<SnowIdOptions>());

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // 添加状态码拦截中间件
        app.UseUnifyResultStatusCodes();

        // 配置多语言，必须在 路由注册之前
        app.UseAppLocalization();

        app.UseStaticFiles(); //启用静态文件
        app.UseRouting();
        app.UseCorsAccessor();//跨域中间件
        //开启身份认证
        app.UseAuthentication();
        app.UseAuthorization();
        // 配置Swagger-Knife4UI（路由前缀一致代表独立，不同则代表共存）
        app.UseKnife4UI(options =>
        {
            options.RoutePrefix = "kapi";
            foreach (var groupInfo in SpecificationDocumentBuilder.GetOpenApiGroups())
            {
                options.SwaggerEndpoint("/" + groupInfo.RouteTemplate, groupInfo.Title);
            }
        });
        app.UseInject(string.Empty);
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

