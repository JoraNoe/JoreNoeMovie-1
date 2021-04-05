using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IAnimationOperaDomainService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<AnimationOpera> CreateAnimationOpera(AnimationOpera model);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<AnimationOpera> EditAnimationOpera(AnimationOpera model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<AnimationOpera> RemovedAnimationOpera(Guid Id);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        Task<IList<AnimationOpera>> AllAnimationOpera();
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<AnimationOpera> SingleAnimationOpera(Guid Id);
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<AnimationOpera>> Pagein(int PageNum,int PageSize);
    }
}
