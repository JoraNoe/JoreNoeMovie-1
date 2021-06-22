using JoreNoeVideo.Abstractions.Values;
using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IMovieCollectionsDomainService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Domain.Models.MovieCollections> AddMovieCollections(Domain.Models.MovieCollections model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Domain.Models.MovieCollections> RemovedMovieCollections(Guid Id);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Domain.Models.MovieCollections> EditMovieCollections(Domain.Models.MovieCollections model);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        Task<IList<Domain.Models.MovieCollections>> AllMovieCollections();
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Domain.Models.MovieCollections> SingleMovieCollections(Guid Id);
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<Domain.Models.MovieCollections>> Pagin(int PageNum, int PageSize);

        /// <summary>
        /// 根据MovieId查询集数
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        Task<IList<Abstractions.Values.MovieCollectionValue>> FindCollectionByMovieId(Guid MovieId);

        /// <summary>
        /// 爬取播放地址
        /// </summary>
        /// <param name="CollectionId"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        Task<Domain.Models.MovieCollections> SinglePlayerAddress(Guid CollectionId,string Path);
    }
}
