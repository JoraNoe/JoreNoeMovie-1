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
    public class AnimationOperaController : ControllerBase
    {
        private readonly IAnimationOperaDomainService animationOperaDomainService;
        public AnimationOperaController(IAnimationOperaDomainService animationOperaDomainService)
        {
            this.animationOperaDomainService = animationOperaDomainService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("CreateAnimationOpera")]
        public async Task<ActionResult<APIReturnInfo<AnimationOpera>>> CreateAnimationOpera(AnimationOpera model)
        {
            return APIReturnInfo<AnimationOpera>.Success(await this.animationOperaDomainService.CreateAnimationOpera(model));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPut("EditAnimationOpera")]
        public async Task<ActionResult<APIReturnInfo<AnimationOpera>>> EditAnimationOpera(AnimationOpera model)
        {
            return APIReturnInfo<AnimationOpera>.Success(await this.animationOperaDomainService.EditAnimationOpera(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{Id}/RemovedAnimationOpera")]
        public async Task<ActionResult<APIReturnInfo<AnimationOpera>>> RemovedAnimationOpera(Guid Id)
        {
            return APIReturnInfo<AnimationOpera>.Success(await this.animationOperaDomainService.RemovedAnimationOpera(Id));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}/SingleAnimationOpera")]
        public async Task<ActionResult<APIReturnInfo<AnimationOpera>>> SingleAnimationOpera(Guid Id)
        {
            return APIReturnInfo<AnimationOpera>.Success(await this.animationOperaDomainService.SingleAnimationOpera(Id));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("AllAnimationOpera")]
        public async Task<ActionResult<APIReturnInfo<IList<AnimationOpera>>>> AllAnimationOpera()
        {
            return APIReturnInfo<IList<AnimationOpera>>.Success(await this.animationOperaDomainService.AllAnimationOpera());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfo<IList<AnimationOpera>>>> Pagin(int PageNum,int PageSize)
        {
            return APIReturnInfo<IList<AnimationOpera>>.Success(await this.animationOperaDomainService.Pagein(PageNum,PageSize));
        }
    }
}
