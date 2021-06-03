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
    public class NoticeController : ControllerBase
    {
        private readonly INoticeDomainService noticeDomainService;
        public NoticeController(INoticeDomainService noticeDomainService)
        {
            this.noticeDomainService = noticeDomainService;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost("CreateNotice")]
        public async Task<ActionResult<APIReturnInfoo<Notice>>> CreateNotice(Notice model)
        {
            return APIReturnInfoo<Notice>.Success(await this.noticeDomainService.CreateNotice(model));
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPut("EditNotice")]
        public async Task<ActionResult<APIReturnInfoo<Notice>>> EditNotice(Notice model)
        {
            return APIReturnInfoo<Notice>.Success(await this.noticeDomainService.EditNotice(model));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{Id}/RemovedNotice")]
        public async Task<ActionResult<APIReturnInfoo<Notice>>> RemovedNotice(Guid Id)
        {
            return APIReturnInfoo<Notice>.Success(await this.noticeDomainService.RemovedNotice(Id));
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}/SingleNotice")]
        public async Task<ActionResult<APIReturnInfoo<Notice>>> SingleNotice(Guid Id)
        {
            return APIReturnInfoo<Notice>.Success(await this.noticeDomainService.SingleNotice(Id));
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("AllNotice")]
        public async Task<ActionResult<APIReturnInfoo<IList<Notice>>>> AllNotice()
        {
            return APIReturnInfoo<IList<Notice>>.Success(await this.noticeDomainService.AllNotice());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        /// 
        [HttpGet("Pagin")]
        public async Task<ActionResult<APIReturnInfoo<IList<Notice>>>> Pagin(int PageNum, int PageSize)
        {
            return APIReturnInfoo<IList<Notice>>.Success(await this.noticeDomainService.Pagin(PageNum, PageSize));
        }
    }
}
