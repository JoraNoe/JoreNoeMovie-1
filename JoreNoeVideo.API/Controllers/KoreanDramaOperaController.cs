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
    public class KoreanDramaOperaController : ControllerBase
    {
        private readonly IKoreanDramaOperaDomainService koreanDramaOperaDomainService;
        public KoreanDramaOperaController(IKoreanDramaOperaDomainService koreanDramaOperaDomainService)
        {
            this.koreanDramaOperaDomainService = koreanDramaOperaDomainService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("CreateKoreanDramaOpera")]
        public async Task<ActionResult<APIReturnInfo<KoreanDramaOpera>>> CreateKoreanDramaOpera(KoreanDramaOpera model)
        {
            return APIReturnInfo<KoreanDramaOpera>.Success(await this.koreanDramaOperaDomainService.CreateKoreanDramaOpera(model));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPut("EditKoreanDramaOpera")]
        public async Task<ActionResult<APIReturnInfo<KoreanDramaOpera>>> EditKoreanDramaOpera(KoreanDramaOpera model)
        {
            return APIReturnInfo<KoreanDramaOpera>.Success(await this.koreanDramaOperaDomainService.EditKoreanDramaOpera(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{Id}/RemovedKoreanDramaOpera")]
        public async Task<ActionResult<APIReturnInfo<KoreanDramaOpera>>> RemovedKoreanDramaOpera(Guid Id)
        {
            return APIReturnInfo<KoreanDramaOpera>.Success(await this.koreanDramaOperaDomainService.RemovedKoreanDramaOpera(Id));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}/SingleKoreanDramaOpera")]
        public async Task<ActionResult<APIReturnInfo<KoreanDramaOpera>>> SingleKoreanDramaOpera(Guid Id)
        {
            return APIReturnInfo<KoreanDramaOpera>.Success(await this.koreanDramaOperaDomainService.SingleKoreanDramaOpera(Id));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("AllKoreanDramaOpera")]
        public async Task<ActionResult<APIReturnInfo<IList<KoreanDramaOpera>>>> AllKoreanDramaOpera()
        {
            return APIReturnInfo<IList<KoreanDramaOpera>>.Success(await this.koreanDramaOperaDomainService.AllKoreanDramaOpera());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        /// 
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfo<IList<KoreanDramaOpera>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInfo<IList<KoreanDramaOpera>>.Success(await this.koreanDramaOperaDomainService.Pagin(PageNum, PageSize));
        }
    }
}
