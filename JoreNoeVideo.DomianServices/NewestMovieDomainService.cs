using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public class NewestMovieDomainService : INewestMovieDomainService
    {
        private readonly IDbContextFace<NewestMovie> server;
        public NewestMovieDomainService(IDbContextFace<NewestMovie> server)
        {
            this.server = server;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<NewestMovie> EditNewestMovie(NewestMovie model)
        {
            return await this.server.EditAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<NewestMovie>> Pagin(int PageNum, int PageSize)
        {
            return await this.server.Page(PageNum, PageSize).ConfigureAwait(false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<NewestMovie> RemovedNewestMovie(Guid Id)
        {
            return await this.server.DeleteAsync(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<NewestMovie> SingleNewestMovie(Guid Id)
        {
            return await this.server.GetSingle(Id).ConfigureAwait(false);
        }
    }
}
