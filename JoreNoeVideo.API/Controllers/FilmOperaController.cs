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
    public class FilmOperaController : ControllerBase
    {
        private readonly IFilmOperaDomainservice filmOperaDomainservice;
        public FilmOperaController(IFilmOperaDomainservice filmOperaDomainservice)
        {
            this.filmOperaDomainservice = filmOperaDomainservice;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("CreateFilmOpera")]
        public async Task<ActionResult<APIReturnInFo<FilmOpera>>> CreateFilmOpera(FilmOpera model)
        {
            return APIReturnInFo<FilmOpera>.Success(await this.filmOperaDomainservice.CreateFilmOpera(model));
        }

        /// <summary>
        /// x编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPut("EditFilmOpera")]
        public async Task<ActionResult<APIReturnInFo<FilmOpera>>> EditFilmOpera(FilmOpera model)
        {
            return APIReturnInFo<FilmOpera>.Success(await this.filmOperaDomainservice.EditFilmOpera(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{Id}/RemovedFilmOpera")]
        public async Task<ActionResult<APIReturnInFo<FilmOpera>>> RemovedFilmOpera(Guid Id)
        {
            return APIReturnInFo<FilmOpera>.Success(await this.filmOperaDomainservice.RemovedFilmOpera(Id));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}/SingleFilmOpera")]
        public async Task<ActionResult<APIReturnInFo<FilmOpera>>> SingleFilmOpera(Guid Id)
        {
            return APIReturnInFo<FilmOpera>.Success(await this.filmOperaDomainservice.SingleFilmOpera(Id));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("AllFilmOpera")]
        public async Task<ActionResult<APIReturnInFo<IList<FilmOpera>>>> AllFilmOpera()
        {
            return APIReturnInFo<IList<FilmOpera>>.Success(await this.filmOperaDomainservice.AllFilmOpera());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        /// 
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInFo<IList<FilmOpera>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInFo<IList<FilmOpera>>.Success(await this.filmOperaDomainservice.Pagin(PageNum,PageSize));
        }
    }
}
