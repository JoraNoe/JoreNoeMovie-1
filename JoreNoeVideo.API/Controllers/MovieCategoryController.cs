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
    public class MovieCategoryController : ControllerBase
    {
        private readonly IMovieCategoryDomainService MovieCategoryDomainService;

        public MovieCategoryController(IMovieCategoryDomainService MovieCategoryDomainService)
        {
            this.MovieCategoryDomainService = MovieCategoryDomainService;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddMovieCategory")]
        public async Task<ActionResult<APIReturnInfo<MovieCategory>>> AddMovieCategory(MovieCategory model)
        {
            return APIReturnInfo<MovieCategory>.Success(await this.MovieCategoryDomainService.AddMovieCategory(model));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("EditMovieCategory")]
        public async Task<ActionResult<APIReturnInfo<MovieCategory>>> EditMovieCategory(MovieCategory model)
        {
            return APIReturnInfo<MovieCategory>.Success(await this.MovieCategoryDomainService.EditMovieCategory(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/RemovedMovieCategory")]
        public async Task<ActionResult<APIReturnInfo<MovieCategory>>> RemovedMovieCategory(Guid Id)
        {
            return APIReturnInfo<MovieCategory>.Success(await this.MovieCategoryDomainService.RemovedMovieCategory(Id));
        }

        /// <summary>
        /// 单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}/SingleMovieCategory")]
        public async Task<ActionResult<APIReturnInfo<MovieCategory>>> SingleMovieCategory(Guid Id)
        {
            return APIReturnInfo<MovieCategory>.Success(await this.MovieCategoryDomainService.SingleMovieCategory(Id));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllMovieCategory")]
        public async Task<ActionResult<APIReturnInfo<IList<MovieCategory>>>> AllMovieCategory()
        {
            return APIReturnInfo<IList<MovieCategory>>.Success(await this.MovieCategoryDomainService.AllMovieCategory());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfo<IList<MovieCategory>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInfo<IList<MovieCategory>>.Success(await this.MovieCategoryDomainService.Pagin(PageNum, PageSize));
        }
    }
}
