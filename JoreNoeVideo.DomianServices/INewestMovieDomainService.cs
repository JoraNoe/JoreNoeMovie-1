using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface INewestMovieDomainService
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<NewestMovie> RemovedNewestMovie(Guid Id);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<NewestMovie> EditNewestMovie(NewestMovie model);
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<NewestMovie> SingleNewestMovie(Guid Id);
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<NewestMovie>> Pagin(int PageNum, int PageSize);
    }
}
