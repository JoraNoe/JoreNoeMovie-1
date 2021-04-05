using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IHongKongOperaDomainService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<HongKongOpera> CreateHongKongOpera(HongKongOpera model);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<HongKongOpera> EditHongKongOpera(HongKongOpera model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<HongKongOpera> RemovedHongKongOpera(Guid Id);
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<HongKongOpera> SingleHongKongOpera(Guid Id);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        Task<IList<HongKongOpera>> AllHongKongOpera();
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<HongKongOpera>> Pagin(int PageNum, int PageSize);
    }
}
