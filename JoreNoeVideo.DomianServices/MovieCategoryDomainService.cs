using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public class MovieCategoryDomainService : IMovieCategoryDomainService
    {
        private readonly IDbContextFace<MovieCategory> Server;
        public MovieCategoryDomainService(IDbContextFace<MovieCategory> Server)
        {
            this.Server = Server;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieCategory> AddMovieCategory(MovieCategory model)
        {
            return await this.Server.AddAsync(model).ConfigureAwait(false);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IList<MovieCategory>> AllMovieCategory()
        {
            return await this.Server.AllAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieCategory> EditMovieCategory(MovieCategory model)
        {
            return await this.Server.EditAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<MovieCategory>> Pagin(int PageNum, int PageSize)
        {
            return await this.Server.Page(PageNum, PageSize).ConfigureAwait(false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieCategory> RemovedMovieCategory(Guid Id)
        {
            return await this.Server.DeleteAsync(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<MovieCategory> SingleMovieCategory(Guid Id)
        {
            return await this.Server.GetSingle(Id).ConfigureAwait(false);
        }
    }
}
