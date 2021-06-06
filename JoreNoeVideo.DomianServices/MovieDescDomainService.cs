using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace JoreNoeVideo.DomainServices
{
    public class MovieDescDomainService : IMovieDescDomainService
    {
        private readonly IDbContextFace<MovieDesc> server;
        public MovieDescDomainService(IDbContextFace<MovieDesc> server)
        {
            this.server = server;
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieDesc> AddMovieDesc(MovieDesc model)
        {
            return await this.server.AddAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IList<MovieDesc>> AllMovieDesc()
        {
            return await this.server.AllAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieDesc> EditMovieDesc(MovieDesc model)
        {
            return await this.server.EditAsync(model).ConfigureAwait(false);
        }



        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<MovieDesc>> Pagin(int PageNum, int PageSize)
        {
            return await this.server.Page(PageNum, PageSize).ConfigureAwait(false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<MovieDesc> RemovedMovieDesc(Guid Id)
        {
            return await this.server.DeleteAsync(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<MovieDesc> SingleMovieDesc(Guid Id)
        {
            return await this.server.GetSingle(Id).ConfigureAwait(false);
        }
        /// <summary>
        /// 根据MovieId获取详情
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        public async Task<MovieDesc> MovieDescByMovieId(Guid MovieId)
        {
            var SingleMovieDesc = await this.server.FindAsync(d => d.MovieId == MovieId.ToString()).ConfigureAwait(false);

            var SingleMent = SingleMovieDesc.FirstOrDefault();

            return SingleMent;
        }
    }
}
