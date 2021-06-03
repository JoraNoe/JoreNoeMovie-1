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
    public class NewestMovieController : ControllerBase
    {
        private readonly INewestMovieDomainService NewestMovieDomainService;
        public NewestMovieController(INewestMovieDomainService NewestMovieDomainService)
        {
            this.NewestMovieDomainService = NewestMovieDomainService;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{Id}/RemovedNewestMovie")]
        public async Task<ActionResult<APIReturnInfo<NewestMovie>>> RemovedNewestMovie(Guid Id)
        {
            return APIReturnInfo<NewestMovie>.Success(await this.NewestMovieDomainService.RemovedNewestMovie(Id));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("EditNewestMovie")]
        public async Task<ActionResult<APIReturnInfo<NewestMovie>>> EditNewestMovie(NewestMovie model)
        {
            return APIReturnInfo<NewestMovie>.Success(await this.NewestMovieDomainService.EditNewestMovie(model));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/SingleNewestMovie")]
        public async Task<ActionResult<APIReturnInfo<NewestMovie>>> SingleNewestMovie(Guid Id)
        {
            return APIReturnInfo<NewestMovie>.Success(await this.NewestMovieDomainService.SingleNewestMovie(Id));
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfo<IList<NewestMovie>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInfo<IList<NewestMovie>>.Success(await this.NewestMovieDomainService.Pagin(PageNum,PageSize));
        }
    }
}
