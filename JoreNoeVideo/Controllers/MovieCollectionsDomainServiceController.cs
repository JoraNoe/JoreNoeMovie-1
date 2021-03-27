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
        public async Task<ActionResult<APIReturnInFo<MovieCollections>>> AddMovieCollectionsDomain(MovieCollections model)
        {
            return APIReturnInFo<MovieCollections>.Success(await this.MovieCollectionsDomainService.AddMovieCollections(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/RemovedMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInFo<MovieCollections>>> RemovedMovieCollectionsDomain(Guid Id)
        {
            return APIReturnInFo<MovieCollections>.Success(await this.MovieCollectionsDomainService.RemovedMovieCollections(Id));
        }

        [HttpPut("EditMovieCollectionsDomain")]
        public async Task<ActionResult<APIReturnInFo<MovieCollections>>> EditMovieCollectionsDomain(MovieCollections model)
        {
            return APIReturnInFo<MovieCollections>.Success(await this.MovieCollectionsDomainService.EditMovieCollections(model));
        }
    }
}
