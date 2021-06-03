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
    public class MovieCollectionsDomainServiceController : ControllerBase
    {
        private readonly IMovieCollectionsDomainService MovieCollectionsDomainService;
        public MovieCollectionsDomainServiceController(IMovieCollectionsDomainService MovieCollectionsDomainService)
        {
            this.MovieCollectionsDomainService = MovieCollectionsDomainService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInfo<MovieCollections>>> AddMovieCollectionsDomain(MovieCollections model)
        {
            return APIReturnInfo<MovieCollections>.Success(await this.MovieCollectionsDomainService.AddMovieCollections(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/RemovedMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInfo<MovieCollections>>> RemovedMovieCollectionsDomain(Guid Id)
        {
            return APIReturnInfo<MovieCollections>.Success(await this.MovieCollectionsDomainService.RemovedMovieCollections(Id));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("EditMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInfo<MovieCollections>>> EditMovieCollectionsDomain(MovieCollections model)
        {
            return APIReturnInfo<MovieCollections>.Success(await this.MovieCollectionsDomainService.EditMovieCollections(model));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInfo<IList<MovieCollections>>>> AllMovieCollectionsDomain()
        {
            return APIReturnInfo<IList<MovieCollections>>.Success(await this.MovieCollectionsDomainService.AllMovieCollections());
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("SingleMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInfo<MovieCollections>>> SingleMovieCollectionsDomain(Guid Id)
        {
            return APIReturnInfo<MovieCollections>.Success(await this.MovieCollectionsDomainService.SingleMovieCollections(Id));
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfo<IList<MovieCollections>>>> Pagin(int PageNum,int PageSize)
        {
            return APIReturnInfo<IList<MovieCollections>>.Success(await this.MovieCollectionsDomainService.Pagin(PageNum,PageSize));
        }

        /// <summary>
        /// 根据MovieId查询集数
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        [HttpGet("{MovieId}")]
        public async Task<APIReturnInfo<IList<MovieCollections>>> FindCollectionByMovieId(string MovieId)
        {
            return APIReturnInfo<IList<MovieCollections>>.Success(await this.MovieCollectionsDomainService.FindCollectionByMovieId(Guid.Parse(MovieId)));
        }

    }
}
