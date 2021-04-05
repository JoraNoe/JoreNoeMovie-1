using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IAmericanOperaDomainService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<AmericanOpera> CreateAmericanOpera(AmericanOpera model);
        /// <summary>
        /// 删除u
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<AmericanOpera> RemovedAmericanOpera(Guid Id);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<AmericanOpera> EditAmericanOpera(AmericanOpera model);
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<AmericanOpera> SingleAmericanOpera(Guid Id);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        Task<IList<AmericanOpera>> AllAmericanOpera();
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<AmericanOpera>> Pagin(int PageNum,int PageSize);
    }
}
