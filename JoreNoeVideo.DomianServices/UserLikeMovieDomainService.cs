using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public class UserLikeMovieDomainService : IUserLikeMovieDomainService
    {
        private readonly IDbContextFace<UserLikeMovie> server;
        public UserLikeMovieDomainService(IDbContextFace<UserLikeMovie> server)
        {
            this.server = server;
        }


        /// <summary>
        /// 添加用户喜欢影片
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        public async Task<UserLikeMovie> CreateUserLikeMovie(Guid UserId, Guid MovieId)
        {
            var Result = await this.server.AddAsync(new UserLikeMovie {
                MovieId = MovieId,
                UserId = UserId
            }).ConfigureAwait(false);
            return Result;
        }

        /// <summary>
        /// 查询是否点过赞
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        public async Task<bool> Exists(Guid UserId, Guid MovieId)
        {
            var Find = await this.server.FindAsync(d=>d.UserId == UserId && d.MovieId == MovieId).ConfigureAwait(false);

            return Find == null;
        }
    }
}
