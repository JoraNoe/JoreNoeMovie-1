using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.Tools;
using JoreNoeVideo.Store;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomianServices
{
    public class UserDomainService : IUserDomainService
    {
        public UserDomainService(IDbContextFace<User> Server,
            IHttpRequestDomainService Http,
            IConfiguration Configuration)
        {
            this.Server = Server;
            this.Http = Http;
            this.Configuration = Configuration;
        }
        private readonly IConfiguration Configuration;
        private readonly IHttpRequestDomainService Http;
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
        /// <summary>
        /// 根据Code获取OpenId
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public Task<string> Authorization(string Code)
        {
            var Configuration = this.Configuration.GetSection("MiniProgress");
            
            var Response = Http.HttpRequest(Configuration["Url"]+Code);

            return null;
        }
    }
}
