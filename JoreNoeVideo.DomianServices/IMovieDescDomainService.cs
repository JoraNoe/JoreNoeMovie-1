using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IMovieDescDomainService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MovieDesc> AddMovieDesc(MovieDesc model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<MovieDesc> RemovedMovieDesc(Guid Id);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MovieDesc> EditMovieDesc(MovieDesc model);
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<MovieDesc> SingleMovieDesc(Guid Id);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        Task<IList<MovieDesc>> AllMovieDesc();
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<MovieDesc>> Pagin(int PageNum, int PageSize);

        /// <summary>
        /// 根据MovieId获取详细信息
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        Task<MovieDesc> MovieDescByMovieId(Guid MovieId);
    }
}
