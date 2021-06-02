using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoreNoeVideo.API.Filter;
using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices;
using JoreNoeVideo.DomainServices.Tools;
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
        public async Task<ActionResult<APIReturnInFo<Movie>>> AddUser([FromBody] Movie Model)
        {
            return APIReturnInFo<Movie>.Success(await this.MovieDomainservice.AddMovie(Model));
        }
        /// <summary>
        /// 查询 index 视频
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<ActionResult<APIReturnInFo<IList<Movie>>>> Movie()
        {
            return APIReturnInFo<IList<Movie>>.Success(await this.MovieDomainservice.GetIndexMovie());
        }

        /// <summary>
        /// 喜欢
        /// </summary>
        /// <returns></returns>
        [HttpPut("{MovieId}/AddLike")]
        public async Task<ActionResult<APIReturnInFo<int>>> AddLike(string MovieId)
        {
            return APIReturnInFo<int>.Success(await this.MovieDomainservice.AddLike(Guid.Parse(UserInfo.Id), Guid.Parse(MovieId)));
        }

        /// <summary>
        /// 不喜欢
        /// </summary>
        /// <returns></returns>
        [HttpPut("{MovieId}/AddDisLike")]
        public async Task<ActionResult<APIReturnInFo<int>>> AddDisLike(string MovieId)
        {
            return APIReturnInFo<int>.Success(await this.MovieDomainservice.AddDisLike(Guid.Parse(UserInfo.Id), Guid.Parse(MovieId)));
        }

    }
}
