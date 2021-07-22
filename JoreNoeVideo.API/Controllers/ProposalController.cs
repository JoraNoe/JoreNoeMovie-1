using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices;
using JoreNoeVideo.DomainServices.ReturnInterFaces;
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
    public class ProposalController : ControllerBase
    {
        private readonly IProposalDomainService ProposalDomainService;

        public ProposalController(IProposalDomainService ProposalDomainService)
        {
            this.ProposalDomainService = ProposalDomainService;
        }

        /// <summary>
        /// 添加建议
        /// </summary>
        /// <param name="CreateInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<APIReturnInfo<Proposal>> CreateProposal(Proposal CreateInfo)
        {
            return await this.ProposalDomainService.CreateProposal(CreateInfo);
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        [HttpGet("Paging")]
        public async Task<APIReturnInfo<ReturnPaging<Proposal>>> Paging(int PageSize = 10, int PageIndex = 1)
        {
            return await this.ProposalDomainService.Paging(PageSize,PageIndex);
        }

    }
}
