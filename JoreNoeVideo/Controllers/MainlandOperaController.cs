﻿using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.Domain;
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
    public class MainlandOperaController : ControllerBase
    {
        private readonly IMainlandOperaDomainService mainlandOperaDomainService;
        public MainlandOperaController(IMainlandOperaDomainService mainlandOperaDomainService)
        {
            this.mainlandOperaDomainService = mainlandOperaDomainService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("CreateMainlandOpera")]
        public async Task<ActionResult<APIReturnInFo<MainlandOpera>>> CreateMainlandOpera(MainlandOpera model)
        {
            return APIReturnInFo<MainlandOpera>.Success(await this.mainlandOperaDomainService.CreateMainlandOpera(model));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPut("EditMainlandOpera")]
        public async Task<ActionResult<APIReturnInFo<MainlandOpera>>> EditMainlandOpera(MainlandOpera model)
        {
            return APIReturnInFo<MainlandOpera>.Success(await this.mainlandOperaDomainService.EditMainlandOpera(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{Id}/RemovedMainlandOpera")]
        public async Task<ActionResult<APIReturnInFo<MainlandOpera>>> RemovedMainlandOpera(Guid Id)
        {
            return APIReturnInFo<MainlandOpera>.Success(await this.mainlandOperaDomainService.RemovedMainlandOpera(Id));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}/SingleMainlandOpera")]
        public async Task<ActionResult<APIReturnInFo<MainlandOpera>>> SingleMainlandOpera(Guid Id)
        {
            return APIReturnInFo<MainlandOpera>.Success(await this.mainlandOperaDomainService.SingleMainlandOpera(Id));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("AllMainlandOpera")]
        public async Task<ActionResult<APIReturnInFo<IList<MainlandOpera>>>> AllMainlandOpera()
        {
            return APIReturnInFo<IList<MainlandOpera>>.Success(await this.mainlandOperaDomainService.AllMainlandOpera());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        /// 
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInFo<IList<MainlandOpera>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInFo<IList<MainlandOpera>>.Success(await this.mainlandOperaDomainService.Pagin(PageNum, PageSize));
        }
    }
}
