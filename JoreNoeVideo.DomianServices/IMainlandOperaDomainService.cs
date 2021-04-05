using JoreNoeVideo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IMainlandOperaDomainService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MainlandOpera> CreateMainlandOpera(MainlandOpera model);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MainlandOpera> EditMainlandOpera(MainlandOpera model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<MainlandOpera> RemovedMainlandOpera(Guid Id);
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<MainlandOpera> SingleMainlandOpera(Guid Id);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        Task<IList<MainlandOpera>> AllMainlandOpera();
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<MainlandOpera>> Pagin(int PageNum, int PageSize);
    }
}
