using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IKoreanDramaOperaDomainService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<KoreanDramaOpera> CreateKoreanDramaOpera(KoreanDramaOpera model);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<KoreanDramaOpera> EditKoreanDramaOpera(KoreanDramaOpera model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<KoreanDramaOpera> RemovedKoreanDramaOpera(Guid Id);
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<KoreanDramaOpera> SingleKoreanDramaOpera(Guid Id);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        Task<IList<KoreanDramaOpera>> AllKoreanDramaOpera();
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<KoreanDramaOpera>> Pagin(int PageNum, int PageSize);
    }
}
