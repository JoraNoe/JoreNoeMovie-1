using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomianServices
{
    public class UserDomainService : IUserDomainService
    {
        public UserDomainService(IDbContextFace<User> Server)
        {
            this.Server = Server;
        }
        private readonly IDbContextFace<User> Server;
        /// <summary>
        /// tianjia
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public async Task<User> AddUser(User Model)
        {
            return await this.Server.AddAsync(Model).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IList<User>> AllUser()
        {
           var Result = await this.Server.AllAsync().ConfigureAwait(false);
            return Result;
        }

        public async Task<User> EditUser(User Model)
        {
            return await this.Server.EditAsync(Model).ConfigureAwait(false);
        }

        public async Task<User> RemoveUser(Guid Id)
        {
            return await this.Server.DeleteAsync(Id).ConfigureAwait(false);
        }

        public async Task<User> SingleUser(Guid Id)
        {
            return await this.Server.GetSingle(Id).ConfigureAwait(false);
        }
    }
}
