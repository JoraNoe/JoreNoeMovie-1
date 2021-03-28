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
    public class MovieMindCollectionsController : ControllerBase
    {
        private readonly IMovieMindCollectionsDomainService MovieMindCollectionsDomainService;
        public MovieMindCollectionsController(IMovieMindCollectionsDomainService MovieMindCollectionsDomainService)
        {
            this.MovieMindCollectionsDomainService = MovieMindCollectionsDomainService;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddMovieMindCollections")]
        public async Task<ActionResult<APIReturnInFo<MovieMindCollections>>> AddMovieMindCollections(MovieMindCollections model)
        {
            return APIReturnInFo<MovieMindCollections>.Success(await this.MovieMindCollectionsDomainService.AddMovieMindCollections(model));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPut("EditMovieMindCollections")]
        public async Task<ActionResult<APIReturnInFo<MovieMindCollections>>> EditMovieMindCollections(MovieMindCollections model)
        {
            return APIReturnInFo<MovieMindCollections>.Success(await this.MovieMindCollectionsDomainService.EditMovieMindCollections(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{Id}/RemovedMovieMindCollections")]
        public async Task<ActionResult<APIReturnInFo<MovieMindCollections>>> RemovedMovieMindCollections(Guid Id)
        {
            return APIReturnInFo<MovieMindCollections>.Success(await this.MovieMindCollectionsDomainService.RemovedMovieMindCollections(Id));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}/SingleMovieMindCollections")]
        public async Task<ActionResult<APIReturnInFo<MovieMindCollections>>> SingleMovieMindCollections(Guid Id)
        {
            return APIReturnInFo<MovieMindCollections>.Success(await this.MovieMindCollectionsDomainService.SingleMovieMindCollections(Id));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("AllMovieMindCollections")]
        public async Task<ActionResult<APIReturnInFo<IList<MovieMindCollections>>>> AllMovieMindCollections()
        {
            return APIReturnInFo<IList<MovieMindCollections>>.Success(await this.MovieMindCollectionsDomainService.AllMovieMindCollections());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        /// 
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInFo<IList<MovieMindCollections>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInFo<IList<MovieMindCollections>>.Success(await this.MovieMindCollectionsDomainService.Pagin(PageNum,PageSize));
        }
    }
}
