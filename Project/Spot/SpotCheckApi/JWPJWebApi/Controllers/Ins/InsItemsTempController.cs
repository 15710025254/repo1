
namespace JWPJWebApi.Controllers
{
    /// <summary>
    /// 点检项目模版
    /// </summary>
    [ApiDescriptionSettings(Name = "InsItemsTemp", Order = 98)]
    [Route("api/InsItemsTemp")]
    public class InsItemsTempController : IDynamicApiController
    {
        private readonly IInsItemsTempService _insItemsTempService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="insItemsTempService"></param>
        public InsItemsTempController(IInsItemsTempService insItemsTempService)
        {
            _insItemsTempService = insItemsTempService;
        }
        /// <summary>
        /// 点检项目模版 分页查询
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        [HttpPost("GetInsItemsTempList")]
        public async Task<PageResult<InsItemsTemp>> GetInsItemsTempList(InsItemsTempInputDto param)
        {
            return await _insItemsTempService.GetInsItemsTempList(param);
        }

        /// <summary>
        /// 点检项目模版 添加
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        [HttpPost("AddInsItemsTemp")]
        public async Task AddInsItemsTemp(AddInsItemsTempInputDto param)
        {
             await _insItemsTempService.AddInsItemsTemp(param);
        }

        /// <summary>
        /// 点检项目模版 修改
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        [HttpPost("UpdateInsItemsTemp")]
        public async Task UpdateInsItemsTemp(UpdateInsItemsTempInputDto param)
        {
            await _insItemsTempService.UpdateInsItemsTemp(param);
        }

        /// <summary>
        /// 点检项目模版 删除
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns></returns>
        [HttpPost("DelInsItemsTemp")]
        public async Task DelInsItemsTemp(long Id)
        {
             await _insItemsTempService.DelInsItemsTemp(Id);
        }
    }
}
