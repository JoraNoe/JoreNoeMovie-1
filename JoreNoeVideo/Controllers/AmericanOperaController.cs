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
    public class AmericanOperaController : ControllerBase
    {
        private readonly IAmericanOperaDomainService americanOperaDomainService;
        public AmericanOperaController(IAmericanOperaDomainService americanOperaDomainService)
        {
            this.americanOperaDomainService = americanOperaDomainService;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("CreateAmericanOpera")]
        public async Task<ActionResult<APIReturnInFo<AmericanOpera>>> CreateAmericanOpera(AmericanOpera model)
        {
            return APIReturnInFo<AmericanOpera>.Success(await this.americanOperaDomainService.CreateAmericanOpera(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{Id}/RemovedAmericanOpera")]
        public async Task<ActionResult<APIReturnInFo<AmericanOpera>>> RemovedAmericanOpera(Guid Id)
        {
            return APIReturnInFo<AmericanOpera>.Success(await this.americanOperaDomainService.RemovedAmericanOpera(Id));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPut("EditAmericanOpera")]
        public async Task<ActionResult<APIReturnInFo<AmericanOpera>>> EditAmericanOpera(AmericanOpera model)
        {
            return APIReturnInFo<AmericanOpera>.Success(await this.americanOperaDomainService.EditAmericanOpera(model));
        }
        
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("AllAmericanOpera")]
        public async Task<ActionResult<APIReturnInFo<IList<AmericanOpera>>>> AllAmericanOpera()
        {
            return APIReturnInFo<IList<AmericanOpera>>.Success(await this.americanOperaDomainService.AllAmericanOpera());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        /// 
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInFo<IList<AmericanOpera>>>> Pagin(int PageNum,int PageSize)
        {
            return APIReturnInFo<IList<AmericanOpera>>.Success(await this.americanOperaDomainService.Pagin(PageNum,PageSize));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}/SingleAmericanOpera")]
        public async Task<ActionResult<APIReturnInFo<AmericanOpera>>> SingleAmericanOpera(Guid Id)
        {
            return APIReturnInFo<AmericanOpera>.Success(await this.americanOperaDomainService.SingleAmericanOpera(Id));
        }
    }
}
