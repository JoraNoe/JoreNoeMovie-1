using JoreNoeVideo.Abstractions.Values;
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
    public class MovieCollectionsController : ControllerBase
    {
        private readonly IMovieCollectionsDomainService MovieCollectionsDomainService;
        public MovieCollectionsController(IMovieCollectionsDomainService MovieCollectionsDomainService)
        {
            this.MovieCollectionsDomainService = MovieCollectionsDomainService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInfo<Domain.Models.MovieCollections>>> AddMovieCollectionsDomain(Domain.Models.MovieCollections model)
        {
            return APIReturnInfo<Domain.Models.MovieCollections>.Success(await this.MovieCollectionsDomainService.AddMovieCollections(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/RemovedMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInfo<Domain.Models.MovieCollections>>> RemovedMovieCollectionsDomain(Guid Id)
        {
            return APIReturnInfo<Domain.Models.MovieCollections>.Success(await this.MovieCollectionsDomainService.RemovedMovieCollections(Id));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("EditMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInfo<Domain.Models.MovieCollections>>> EditMovieCollectionsDomain(Domain.Models.MovieCollections model)
        {
            return APIReturnInfo<Domain.Models.MovieCollections>.Success(await this.MovieCollectionsDomainService.EditMovieCollections(model));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInfo<IList<Domain.Models.MovieCollections>>>> AllMovieCollectionsDomain()
        {
            return APIReturnInfo<IList<Domain.Models.MovieCollections>>.Success(await this.MovieCollectionsDomainService.AllMovieCollections());
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("SingleMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInfo<Domain.Models.MovieCollections>>> SingleMovieCollectionsDomain(Guid Id)
        {
            return APIReturnInfo<Domain.Models.MovieCollections>.Success(await this.MovieCollectionsDomainService.SingleMovieCollections(Id));
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfo<IList<Domain.Models.MovieCollections>>>> Pagin(int PageNum,int PageSize)
        {
            return APIReturnInfo<IList<Domain.Models.MovieCollections>>.Success(await this.MovieCollectionsDomainService.Pagin(PageNum, PageSize));
        }

        /// <summary>
        /// 根据MovieId查询集数
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        [HttpGet("{MovieId}")]
        public async Task<APIReturnInfo<IList<Abstractions.Values.MovieCollectionValue>>> FindCollectionByMovieId(string MovieId)
        {
            return APIReturnInfo<IList<Abstractions.Values.MovieCollectionValue>>.Success(await this.MovieCollectionsDomainService.FindCollectionByMovieId(Guid.Parse(MovieId)));
        }

        /// <summary>
        /// 查询视频播放地址
        /// </summary>
        /// <param name="CollectionId"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        [HttpGet("Single/{CollectionId}")]
        public async Task<APIReturnInfo<Domain.Models.MovieCollections>> SinglePlayerAddress(Guid CollectionId, string Path)
        {
            return APIReturnInfo<Domain.Models.MovieCollections>.Success(await this.MovieCollectionsDomainService.SinglePlayerAddress(CollectionId, Path).ConfigureAwait(false));
        }

    }
}
