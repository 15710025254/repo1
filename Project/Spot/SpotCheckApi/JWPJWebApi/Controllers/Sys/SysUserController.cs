
namespace JWPJWebApi.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [ApiDescriptionSettings(Name = "SysUser", Order =899)]
    [Route("api/SysUser")]
    public class SysUserController : IDynamicApiController
    {
        private readonly ISysUserService _sysUserService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sysUserService"></param>
        public SysUserController(ISysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }
        /// <summary>
        /// 获取用户分页列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("Page")]
        public async Task<PageResult<SysUser>> Page(PageUserInput param)
        {
            return await _sysUserService.Page(param);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public async Task AddUser(AddUserInput param)
        {
             await _sysUserService.AddUser(param);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateUser")]
        public async Task UpdateUser(UpdateUserInput param)
        {
            await _sysUserService.UpdateUser(param);
        }
    }
}
