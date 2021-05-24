using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomianServices
{
    public interface IUserDomainService
    {
        Task<User> AddUser(User Model);
        Task<User> EditUser(User Model);
        Task<User> RemoveUser(Guid Id);
        Task<User> SingleUser(Guid Id);
        Task<IList<User>> AllUser();
        /// <summary>
        /// 根据Code 获取用户OpenId
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        Task<string> Authorization(string Code);
        /// <summary>
        /// 根据用户OpenId查询数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<User> FindUserByUserOpenId(string Id);
    }
}
