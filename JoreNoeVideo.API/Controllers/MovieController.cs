using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoreNoeVideo.API.Filter;
using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices;
using JoreNoeVideo.DomainServices.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using Quartz.Impl;

namespace JoreNoeVideo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public MovieController(IMoviceDomainService MovieDomainservice)
        {
            this.MovieDomainservice = MovieDomainservice;
        }
        private readonly IMoviceDomainService MovieDomainservice;
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public async Task<ActionResult<APIReturnInfo<Movie>>> AddUser([FromBody] Movie Model)
        {
            return APIReturnInfo<Movie>.Success(await this.MovieDomainservice.AddMovie(Model));
        }
        /// <summary>
        /// 查询 index 视频
        /// </summary>
        /// <returns></returns>
        [HttpGet("IndexMovie")]
        public async Task<ActionResult<APIReturnInfo<IList<Movie>>>> Movie()
        {
            return APIReturnInfo<IList<Movie>>.Success(await this.MovieDomainservice.GetIndexMovie());
        }

        /// <summary>
        /// 喜欢
        /// </summary>
        /// <returns></returns>
        [HttpPut("{MovieId}/AddLike")]
        public async Task<ActionResult<APIReturnInfo<int>>> AddLike(string MovieId)
        {
            return APIReturnInfo<int>.Success(await this.MovieDomainservice.AddLike(Guid.Parse(this.UserId()), Guid.Parse(MovieId)));
        }

        /// <summary>
        /// 不喜欢
        /// </summary>
        /// <returns></returns>
        [HttpPut("{MovieId}/AddDisLike")]
        public async Task<ActionResult<APIReturnInfo<int>>> AddDisLike(string MovieId)
        {
            return APIReturnInfo<int>.Success(await this.MovieDomainservice.AddDisLike(Guid.Parse(this.UserId()), Guid.Parse(MovieId)));
        }


        /// <summary>
        /// 根据影视类型查看全部影视信息
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpGet("{CategoryId}/FindMovieByMovieCategoryId")]
        public async Task<ActionResult<APIReturnInfo<IList<Movie>>>> FindMovieByMovieCategoryId(string CategoryId)
        {
            return APIReturnInfo<IList<Movie>>.Success(await this.MovieDomainservice.FindMovieByMovieCategoryId(CategoryId));
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="SearchMovieName"></param>
        /// <returns></returns>
        [HttpGet("{SearchMovieName}/SearchMovie")]
        public async Task<APIReturnInfo<IList<Movie>>> SearchMovie(string SearchMovieName)
        {
            return await this.MovieDomainservice.SearchMovie(SearchMovieName);
        }

    }
}
