
namespace JWPJWebApi.Controllers
{

    /// <summary>
    /// 常量单位
    /// </summary>
    [ApiDescriptionSettings(Name = "InsUnit", Order = 95)]
    [Route("api/InsUnit")]
    public class InsUnitController : IDynamicApiController
    {
        private readonly IInsUnitService _InsUnitService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InsUnitService"></param>
        public InsUnitController(IInsUnitService InsUnitService)
        {
            _InsUnitService = InsUnitService;
        }
        /// <summary>
        ///  常量单位 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetInsUnitPageList")]
        public async Task<PageResult<InsUnit>> GetInsUnitPageList(InsUnitInputDto param)
        {
            return await _InsUnitService.GetInsUnitPageList(param);
        }

        /// <summary>
        /// 常量单位 查询所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetInsUnitList")]
        public async Task<List<InsUnit>> GetInsUnitList()
        {
            return await _InsUnitService.GetInsUnitList();
        }

        /// <summary>
        /// 常量单位 添加
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        [HttpPost("AddInsUnit")]
        public async Task AddInsUnit(AddInsUnitInputDto param)
        {
            await _InsUnitService.AddInsUnit(param);
        }

        /// <summary>
        /// 常量单位 修改
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        [HttpPost("UpdateInsUnit")]
        public async Task UpdateInsUnit(UpdateInsUnitInputDto param)
        {
            await _InsUnitService.UpdateInsUnit(param);
        }

        /// <summary>
        /// 常量单位 删除
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns></returns>
        [HttpPost("DelInsUnit")]
        public async Task DelInsUnit(long Id)
        {
            await _InsUnitService.DelInsUnit(Id);
        }
    }
}
