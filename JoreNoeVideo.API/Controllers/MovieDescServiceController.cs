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
    public class MovieDescServiceController : ControllerBase
    {
        private readonly IMovieDescDomainService MovieDescDomainService;
        public MovieDescServiceController(IMovieDescDomainService MovieDescDomainService)
        {
            this.MovieDescDomainService = MovieDescDomainService;
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("AddMovieDesc")]
        public async Task<ActionResult<APIReturnInfo<MovieDesc>>> AddMovieDesc(MovieDesc model)
        {
            return APIReturnInfo<MovieDesc>.Success(await this.MovieDescDomainService.AddMovieDesc(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/RemovedMovieDesc")]
        public async Task<ActionResult<APIReturnInfo<MovieDesc>>> RemovedMovieDesc(Guid Id)
        {
            return APIReturnInfo<MovieDesc>.Success(await this.MovieDescDomainService.RemovedMovieDesc(Id));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPut("EditMovieDesc")]
        public async Task<ActionResult<APIReturnInfo<MovieDesc>>> EditMovieDesc(MovieDesc model)
        {
            return APIReturnInfo<MovieDesc>.Success(await this.MovieDescDomainService.EditMovieDesc(model));
        }


        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMovieDesc")]
        public async Task<ActionResult<APIReturnInfo<IList<MovieDesc>>>> AllMovieDesc()
        {
            return APIReturnInfo<IList<MovieDesc>>.Success(await this.MovieDescDomainService.AllMovieDesc());
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/SingleMovieDesc")]
        public async Task<ActionResult<APIReturnInfo<MovieDesc>>> SingleMovieDesc(Guid Id)
        {
            return APIReturnInfo<MovieDesc>.Success(await this.MovieDescDomainService.SingleMovieDesc(Id));
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfo<IList<MovieDesc>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInfo<IList<MovieDesc>>.Success(await this.MovieDescDomainService.Pagin(PageNum,PageSize));
        }

        /// <summary>
        /// 根据视频Id查询详情
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<APIReturnInfo<MovieDesc>> MovieDescByMovieId(string MovieId)
        {
            return APIReturnInfo<MovieDesc>.Success(await this.MovieDescDomainService.MovieDescByMovieId(Guid.Parse(MovieId)));
        }

    }
}
