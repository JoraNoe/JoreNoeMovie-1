using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace JoreNoeVideo.DomainServices
{
    public class UserHelper
    {
        /// <summary>
        /// 根据OpenID查询单个信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public User FindUserByUserOpenId(string Id)
        {
            IDbContextFace<User> DbUser = new DbContextFace<User>();
            if (string.IsNullOrEmpty(Id))
                throw new ArgumentNullException(nameof(Id));

            var Result = DbUser.Find(d => d.UserId == Id);
            return Result.FirstOrDefault();
        }
    }
}
