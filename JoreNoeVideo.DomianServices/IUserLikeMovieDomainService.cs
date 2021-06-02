using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IUserLikeMovieDomainService
    {
        /// <summary>
        /// 添加用户喜欢影片
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        Task<UserLikeMovie> CreateUserLikeMovie(Guid UserId,Guid MovieId);

        /// <summary>
        /// 查询此用户是否给次影片点过赞
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        Task<bool> Exists(Guid UserId,Guid MovieId);
    }
}
