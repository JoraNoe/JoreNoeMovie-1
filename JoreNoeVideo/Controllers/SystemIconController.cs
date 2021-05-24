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
    public class SystemIconController : ControllerBase
    {
        private readonly ISystemIconDomainService systemIconDomainService;
        public SystemIconController(SystemIconDomainService systemIconDomainService)
        {
            this.systemIconDomainService = systemIconDomainService;
        }

        /// <summary>
        /// 新增或编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("CreateSystemIcon")]
        public async Task<ActionResult<APIReturnInFo<SystemIcon>>> CreateSystemIcon(SystemIcon model)
        {
            var Item = await this.systemIconDomainService.SingleSystemIcon(model.Id);
            if(Item == null)
            {
                return APIReturnInFo<SystemIcon>.Success(await this.systemIconDomainService.CreateSystemIcon(model));
            }
            else
            {
                return APIReturnInFo<SystemIcon>.Success(await this.systemIconDomainService.EditSystemIcon(model));
            }
            
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}/SingleSystemIcon")]
        public async Task<ActionResult<APIReturnInFo<SystemIcon>>> SingleSystemIcon(Guid Id)
        {
            return APIReturnInFo<SystemIcon>.Success(await this.systemIconDomainService.SingleSystemIcon(Id));
        }
    }
}
