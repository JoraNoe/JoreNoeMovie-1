using JoreNoeVideo.Abstractions.Models;
using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IUserWatchHistoryDomainService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserWatchHistory> AddUserWatchHistory(UserWatchHistory model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<UserWatchHistory> RemovedUserWatchHistory(Guid Id);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserWatchHistory> EditUserWatchHistory(UserWatchHistory model);
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<UserWatchHistory> SingleUserWatchHistory(Guid Id);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        Task<IList<UserWatchHistory>> AllUserWatchHistory();
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<UserWatchHistory>> Pagin(int PageNum, int PageSize);

        /// <summary>
        /// 根据用户UseId 查询  观看历史记录
        /// </summary>
        /// <param name="UseId"></param>
        /// <returns></returns>
        Task<IList<UserWatchHistoryValue>> FindWatchHistoryByUserId(string UseId);
    }
}
