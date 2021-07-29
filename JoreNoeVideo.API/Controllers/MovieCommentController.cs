using JoreNoeVideo.Abstractions.Values;
using JoreNoeVideo.API.Filter;
using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.Domain;
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
    public class MovieCommentController : ControllerBase
    {
        private readonly IMovieCommentDomainService MovieCommentDomainService;
        public MovieCommentController(IMovieCommentDomainService MovieCommentDomainService)
        {
            this.MovieCommentDomainService = MovieCommentDomainService;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddMovieComment")]
        public async Task<ActionResult<APIReturnInfo<MovieCommentValue>>> AddMovieComment(MovieComment model)
        {
            model.UserId = Guid.Parse(this.UserId());
            return APIReturnInfo<MovieCommentValue>.Success(await this.MovieCommentDomainService.AddMovieComment(model));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("EditMovieComment")]
        public async Task<ActionResult<APIReturnInfo<MovieComment>>> EditMovieComment(MovieComment model)
        {
            return APIReturnInfo<MovieComment>.Success(await this.MovieCommentDomainService.EditMovieComment(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/RemovedMovieComment")]
        public async Task<ActionResult<APIReturnInfo<MovieComment>>> RemovedMovieComment(Guid Id)
        {
            return APIReturnInfo<MovieComment>.Success(await this.MovieCommentDomainService.RemovedMovieComment(Id));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/SingleMovieComment")]
        public async Task<ActionResult<APIReturnInfo<MovieComment>>> SingleMovieComment(Guid Id)
        {
            return APIReturnInfo<MovieComment>.Success(await this.MovieCommentDomainService.SingleMovieComment(Id));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMovieComment")]
        public async Task<ActionResult<APIReturnInfo<IList<MovieComment>>>> AllMovieComment()
        {
            return APIReturnInfo<IList<MovieComment>>.Success(await this.MovieCommentDomainService.AllMovieComment());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfo<IList<MovieComment>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInfo<IList<MovieComment>>.Success(await this.MovieCommentDomainService.Pagin(PageNum, PageSize));
        }

        /// <summary>
        /// 根据MovieId查询评论
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<APIReturnInfo<IList<MovieCommentValue>>> FindMovieCommentByMovieId(string Id)
        {
            return APIReturnInfo<IList<MovieCommentValue>>.Success(await this.MovieCommentDomainService.FindMovieCommentByMovieId(Guid.Parse(Id)));
        }

    }
}
