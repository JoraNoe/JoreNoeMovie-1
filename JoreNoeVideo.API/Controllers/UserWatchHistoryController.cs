using JoreNoeVideo.Abstractions.Models;
using JoreNoeVideo.API.Filter;
using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoreNoeVideo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWatchHistoryController : ControllerBase
    {
        private readonly IUserWatchHistoryDomainService UserWatchHistoryDomainService;
        public UserWatchHistoryController(IUserWatchHistoryDomainService UserWatchHistoryDomainService)
        {
            this.UserWatchHistoryDomainService = UserWatchHistoryDomainService;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("AddUserWatchHistory")]
        public async Task<ActionResult<APIReturnInfo<UserWatchHistory>>> AddUserWatchHistory(UserWatchHistory model)
        {
            model.UserId = this.UserId();

            return await this.UserWatchHistoryDomainService.AddUserWatchHistory(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{Id}/RemovedUserWatchHistory")]
        public async Task<ActionResult<APIReturnInfo<UserWatchHistory>>> RemovedUserWatchHistory(Guid Id)
        {
            return APIReturnInfo<UserWatchHistory>.Success(await this.UserWatchHistoryDomainService.RemovedUserWatchHistory(Id));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPut("EditUserWatchHistory")]
        public async Task<ActionResult<APIReturnInfo<UserWatchHistory>>> EditUserWatchHistory(UserWatchHistory model)
        {
            return APIReturnInfo<UserWatchHistory>.Success(await this.UserWatchHistoryDomainService.EditUserWatchHistory(model));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}/SingleUserWatchHistory")]
        public async Task<ActionResult<APIReturnInfo<UserWatchHistory>>> SingleUserWatchHistory(Guid Id)
        {
            return APIReturnInfo<UserWatchHistory>.Success(await this.UserWatchHistoryDomainService.SingleUserWatchHistory(Id));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("AllUserWatchHistory")]
        public async Task<ActionResult<APIReturnInfo<IList<UserWatchHistory>>>> AllUserWatchHistory()
        {
            return APIReturnInfo<IList<UserWatchHistory>>.Success(await this.UserWatchHistoryDomainService.AllUserWatchHistory());
        }

        /// <summary>
        /// 根据用户Id查询观看历史记录
        /// </summary>
        /// <returns></returns>
        [HttpGet("FindWathcHistory")]
        public async Task<ActionResult<APIReturnInfo<IList<UserWatchHistoryValue>>>> FindWathcHistory()
        {
            return APIReturnInfo<IList<UserWatchHistoryValue>>.Success(await this.UserWatchHistoryDomainService.FindWatchHistoryByUserId(this.UserId()));
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        /// 
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfo<IList<UserWatchHistory>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInfo<IList<UserWatchHistory>>.Success(await this.UserWatchHistoryDomainService.Pagin(PageNum, PageSize));
        }


    }
}
