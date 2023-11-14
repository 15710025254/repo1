
namespace JWPJWebApi.Controllers
{
    /// <summary>
    /// 系统登录授权服务
    /// </summary>
    [ApiDescriptionSettings(Name = "SysAuth", Order = 999)]
    [Route("api/SysAuth")]
    public class SysAuthController : IDynamicApiController, ITransient
    {
        //引入多语言文件
        private readonly IStringLocalizer _localizer;
        private readonly UserManager _userManager;
        private readonly ISysUserService _sysUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="localizer"></param>
        /// <param name="sysUserService"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="userManager"></param>
        public SysAuthController(IStringLocalizerFactory localizer, ISysUserService sysUserService, IHttpContextAccessor httpContextAccessor, UserManager userManager)
        {
            _localizer = localizer.Create();
            _sysUserService = sysUserService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        /// <summary>
        /// 账号密码登录
        /// </summary>
        /// <param name="input"></param>
        /// <remarks>用户名/密码：superadmin/123456</remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<LoginOutputDto> Login([Required] LoginInputDto input)
        {
            //// 账号是否存在
            //var user = await _sysUserService.Login(input);
            //if (user == null)
            //{

            //}
            if (input.Account != "JW22080108")
                throw Oops.Oh(ErrorCodeEnum.D0009);
            
            if (input.Password != "Aa123123!!")
                throw Oops.Oh(ErrorCodeEnum.D1000);

            TokenModel tokenModel = new TokenModel();
            tokenModel.Id = "d7522e60-9b59-43b1-821e-291501d8836f";
            tokenModel.Uid = "JW22080108";
            tokenModel.UserName2 = "";
            var roles = new List<RolesDto>()
            {
               new RolesDto{ DataScope = "全部",Id = 1.0M, name = "管理员",Level = 1.0M }
            };
            tokenModel.Role = roles;
            tokenModel.Project = "buyweb";
            tokenModel.TokenType = "";
            tokenModel.COMPANY_NO = "JW";
            var compans = new List<CompanysDto>()
            {
                new CompanysDto{ Id="JW",Pid="CQ",Name="合肥经纬"},
                new CompanysDto{ Id="JS",Pid="CQ",Name="合肥精深"},
                new CompanysDto{ Id="BD",Pid="CQ",Name="合肥博大"}
            };
            tokenModel.DeptScope = JsonConvert.DeserializeObject<List<CompanysDto>>(JsonConvert.SerializeObject(compans));
            return CreateToken(tokenModel);
        }

        ///// <summary>
        ///// 获取登录账号
        ///// </summary>
        ///// <returns></returns>
        //[DisplayName("获取登录账号")]
        //public async Task<LoginUserOutput> GetUserInfo()
        //{
        //    var user = await _sysUserRep.GetFirstAsync(u => u.Id == _userManager.UserId) ?? throw Oops.Oh(ErrorCodeEnum.D1011).StatusCode(401);
        //    // 获取机构
        //    var org = await _sysUserRep.ChangeRepository<SqlSugarRepository<SysOrg>>().GetFirstAsync(u => u.Id == user.OrgId);
        //    // 获取职位
        //    var pos = await _sysUserRep.ChangeRepository<SqlSugarRepository<SysPos>>().GetFirstAsync(u => u.Id == user.PosId);
        //    // 获取拥有按钮权限集合
        //    var buttons = await _sysMenuService.GetOwnBtnPermList();

        //    return new LoginUserOutput
        //    {
        //        Id = user.Id,
        //        Account = user.Account,
        //        RealName = user.RealName,
        //        Avatar = user.Avatar,
        //        Address = user.Address,
        //        Signature = user.Signature,
        //        OrgId = user.OrgId,
        //        OrgName = org?.Name,
        //        OrgType = org?.Type,
        //        PosName = pos?.Name,
        //        Buttons = buttons
        //    };
        //}
        /// <summary>
        /// Swagger登录检查
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("/swagger/checkUrl"), NonUnify]
        [DisplayName("Swagger登录检查")]
        public int SwaggerCheckUrl()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ? 200 : 401;
        }

        /// <summary>
        /// Swagger登录提交
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("/swagger/submitUrl"), NonUnify]
        [DisplayName("Swagger登录提交")]
        public async Task<int> SwaggerSubmitUrl([FromForm] SpecificationAuth auth)
        {
            try
            {
               await Login(new LoginInputDto
                {
                    Account = auth.UserName,
                    Password = auth.Password
                });
                return 200;
            }
            catch (Exception)
            {
                return 401;
            }
        }

        /// <summary>
        /// Swagger退出系统
        /// </summary>
        [DisplayName("退出系统")]
        public void Logout()
        {
            if (string.IsNullOrWhiteSpace(_userManager.Account))
                throw Oops.Oh(ErrorCodeEnum.D1011);

            _httpContextAccessor.HttpContext.SignoutToSwagger();

        }

        #region 生成Token

        /// <summary>
        /// 生成Token令牌
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [NonAction]
        public LoginOutputDto CreateToken(TokenModel user)
        {
            // 生成Token令牌
            var tokenExpire = 10080;
            var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>
            {
                { ClaimConst.UserId, user.Id },
                { ClaimConst.Account, user.Uid },
                { ClaimConst.AccountTemp, user.UserName2 },
                { ClaimConst.Role , JsonConvert.SerializeObject(user.Role) },
                { ClaimConst.TokenType, user.TokenType },
                { ClaimConst.Companyno, user.COMPANY_NO },
                { ClaimConst.Project, user.Project },
                { ClaimConst.DeptScope, JsonConvert.SerializeObject(user.DeptScope) },
            }, tokenExpire);

            // 生成刷新Token令牌
            var refreshTokenExpire = 20160;
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken, refreshTokenExpire);

            // 设置响应报文头
            _httpContextAccessor.HttpContext.SetTokensOfResponseHeaders(accessToken, refreshToken);

            return new LoginOutputDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        #endregion

        #region 解析Token

        /// <summary>
        /// 解析Token并生成新的Token
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ReadToken")]
        public LoginOutputDto ReadToken(string token)
        {
            var claims = JWTEncryption.ReadJwtToken(token)?.Claims;
            TokenModel tokenModel = new TokenModel();
            tokenModel.Id = claims.FirstOrDefault(u => u.Type == ClaimConst.UserId)?.Value;
            tokenModel.Uid = claims.FirstOrDefault(u => u.Type == ClaimConst.Account)?.Value;
            tokenModel.UserName2 = claims.FirstOrDefault(u => u.Type == ClaimConst.AccountTemp)?.Value;
            tokenModel.Role = JsonConvert.DeserializeObject<List<RolesDto>>(claims.FirstOrDefault(u => u.Type == ClaimConst.Role)?.Value);
            tokenModel.Project = claims.FirstOrDefault(u => u.Type == ClaimConst.Project)?.Value;
            tokenModel.TokenType = claims.FirstOrDefault(u => u.Type == ClaimConst.TokenType)?.Value;
            tokenModel.COMPANY_NO = claims.FirstOrDefault(u => u.Type == ClaimConst.Companyno)?.Value;
            tokenModel.DeptScope = JsonConvert.DeserializeObject<List<CompanysDto>>(claims.FirstOrDefault(u => u.Type == ClaimConst.DeptScope)?.Value);
            return CreateToken(tokenModel);
        }

        #endregion
    }
}
