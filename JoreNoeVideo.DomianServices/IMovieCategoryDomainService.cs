using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IMovieCategoryDomainService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MovieCategory> AddMovieCategory(MovieCategory model);
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MovieCategory> RemovedMovieCategory(Guid Id);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MovieCategory> EditMovieCategory(MovieCategory model);
        /// <summary>
        /// 单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<MovieCategory> SingleMovieCategory(Guid Id);
        /// <summary>
        /// 全部
        /// </summary>
        /// <returns></returns>
        Task<IList<MovieCategory>> AllMovieCategory();
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<MovieCategory>> Pagin(int PageNum, int PageSize);
    }
}
