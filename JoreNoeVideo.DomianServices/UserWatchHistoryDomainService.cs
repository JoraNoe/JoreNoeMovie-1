using JoreNoeVideo.Abstractions.Models;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using JoreNoeVideo.CommonInterFaces;

namespace JoreNoeVideo.DomainServices
{
    public class UserWatchHistoryDomainService : IUserWatchHistoryDomainService
    {
        private readonly IDbContextFace<UserWatchHistory> server;
        private readonly IDbContextFace<Movie> Movie;
        public UserWatchHistoryDomainService(IDbContextFace<UserWatchHistory> server,
            IDbContextFace<Movie> Movie)
        {
            this.server = server;
            this.Movie = Movie;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<APIReturnInfo<UserWatchHistory>> AddUserWatchHistory(UserWatchHistory model)
        {
            if (!this.server.Exist(d => d.MovieId == model.MovieId && d.UserId == model.UserId))
                return APIReturnInfo<UserWatchHistory>.Success(await this.server.AddAsync(model).ConfigureAwait(false));
            else
                return APIReturnInfo<UserWatchHistory>.Error("数据已存在");
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IList<UserWatchHistory>> AllUserWatchHistory()
        {
            return await this.server.AllAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UserWatchHistory> EditUserWatchHistory(UserWatchHistory model)
        {
            return await this.server.EditAsync(model).ConfigureAwait(false);
        }
        /// <summary>
        /// 根据用户查历史记录
        /// </summary>
        /// <param name="UseId"></param>
        /// <returns></returns>
        public async Task<IList<Movie>> FindWatchHistoryByUserId(string UseId)
        {
            var Result = await this.server.FindAsync(d => d.UserId == UseId);

            var MoviesIdsArray = Result.Select(d => d.MovieId).ToArray();

            //查询视频
            var MovieIfnos = await this.Movie.FindAsync(d => MoviesIdsArray.Contains(d.Id));

            return MovieIfnos;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<UserWatchHistory>> Pagin(int PageNum, int PageSize)
        {
            return await this.server.Page(PageNum, PageSize).ConfigureAwait(false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<UserWatchHistory> RemovedUserWatchHistory(Guid Id)
        {
            return await this.server.DeleteRangeAsync(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<UserWatchHistory> SingleUserWatchHistory(Guid Id)
        {
            return await this.server.GetSingle(Id).ConfigureAwait(false);
        }
    }
}
