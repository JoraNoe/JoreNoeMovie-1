using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IMoviceDomainService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        Task<Movie> AddMovie(Movie Model);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        Task<Movie> EditMovie(Movie Model);
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Movie> RemoveMovie(Guid Id);

        Task<Movie> SingleMovie(Guid Id);
        Task<IList<Movie>> AllMovie();
        Task<IList<Movie>> Pagin(int PageNum,int PageSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        Task<IList<Movie>> FindByMovieIdsMovie(Guid[] MovieIds);

        /// <summary>
        /// 获取首页视频信息
        /// </summary>
        /// <returns></returns>
        Task<IList<Movie>> GetIndexMovie();

        /// <summary>
        /// 喜欢
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<int> AddLike(Guid Id,Guid MovieId);
        /// <summary>
        /// 不喜欢
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<int> AddDisLike(Guid Id, Guid MovieId);
    }
}
