using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.ReturnInterFaces;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public class ProposalDomainService : IProposalDomainService
    {
        /// <summary>
        /// 建议服务
        /// </summary>
        private readonly IDbContextFace<Proposal> ProposalService;

        public ProposalDomainService(IDbContextFace<Proposal> ProposalService)
        {
            this.ProposalService = ProposalService;
        }

        /// <summary>
        /// 添加建议
        /// </summary>
        /// <param name="CreateInfo"></param>
        /// <returns></returns>
        public async Task<APIReturnInfo<Proposal>> CreateProposal(Proposal CreateInfo)
        {
            return APIReturnInfo<Proposal>.Success(await this.ProposalService.AddAsync(CreateInfo));
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public async Task<APIReturnInfo<ReturnPaging<Proposal>>> Paging(int PageSize = 10, int PageIndex = 1)
        {
            return APIReturnInfo<ReturnPaging<Proposal>>.Success(new ReturnPaging<Proposal>(
                await this.ProposalService.Page(PageIndex,PageSize).ConfigureAwait(false),
                await this.ProposalService.TotalAsync().ConfigureAwait(false)));
        }
    }
}
