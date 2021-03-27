using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
