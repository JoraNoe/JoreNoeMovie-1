using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.ReturnInterFaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IProposalDomainService
    {
        /// <summary>
        /// 添加一条建议
        /// </summary>
        /// <param name="CreateInfo"></param>
        /// <returns></returns>
        Task<APIReturnInfo<Proposal>> CreateProposal(Proposal CreateInfo);
        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        Task<APIReturnInfo<ReturnPaging<Proposal>>> Paging(int PageSize = 10,int PageIndex = 1);
    }
}
