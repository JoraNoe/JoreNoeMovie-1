﻿using JoreNoeVideo.CommonInterFaces;
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
    public class HongKongOperaController : ControllerBase
    {
        private readonly IHongKongOperaDomainService hongKongOperaDomainService;
        public HongKongOperaController(IHongKongOperaDomainService hongKongOperaDomainService)
        {
            this.hongKongOperaDomainService = hongKongOperaDomainService;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("CreateHongKongOpera")]
        public async Task<ActionResult<APIReturnInfo<HongKongOpera>>> CreateHongKongOpera(HongKongOpera model)
        {
            return APIReturnInfo<HongKongOpera>.Success(await this.hongKongOperaDomainService.CreateHongKongOpera(model));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPut("EditHongKongOpera")]
        public async Task<ActionResult<APIReturnInfo<HongKongOpera>>> EditHongKongOpera(HongKongOpera model)
        {
            return APIReturnInfo<HongKongOpera>.Success(await this.hongKongOperaDomainService.EditHongKongOpera(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{Id}/RemovedHongKongOpera")]
        public async Task<ActionResult<APIReturnInfo<HongKongOpera>>> RemovedHongKongOpera(Guid Id)
        {
            return APIReturnInfo<HongKongOpera>.Success(await this.hongKongOperaDomainService.RemovedHongKongOpera(Id));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}/SingleHongKongOpera")]
        public async Task<ActionResult<APIReturnInfo<HongKongOpera>>> SingleHongKongOpera(Guid Id)
        {
            return APIReturnInfo<HongKongOpera>.Success(await this.hongKongOperaDomainService.SingleHongKongOpera(Id));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("AllHongKongOpera")]
        public async Task<ActionResult<APIReturnInfo<IList<HongKongOpera>>>> AllHongKongOpera()
        {
            return APIReturnInfo<IList<HongKongOpera>>.Success(await this.hongKongOperaDomainService.AllHongKongOpera());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        /// 
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfo<IList<HongKongOpera>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInfo<IList<HongKongOpera>>.Success(await this.hongKongOperaDomainService.Pagin(PageNum, PageSize));
        }
    }
}
