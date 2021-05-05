using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices;
using JoreNoeVideo.DomainServices.Tools;
using JoreNoeVideo.Store;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace JoreNoeVideo.DomianServices
{
    public class UserDomainService : IUserDomainService
    {
        public UserDomainService(IDbContextFace<User> Server,IConfiguration Configuration
           
            )
        {
            this.Server = Server;
            this.Http = RelitClass.HttpRequestDomain;
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
            //查询是否选在
            if (this.Server.All().Any(d => d.UserId == Model.UserId))
                return this.Server.All().Single(d => d.UserId == Model.UserId);
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
        /// <summary>
        ///
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<User> RemoveUser(Guid Id)
        {
            return await this.Server.DeleteAsync(Id).ConfigureAwait(false);
        }
        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
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
            if(string.IsNullOrEmpty(Code))
                throw new ArgumentNullException(nameof(Code));

            var Configuration = this.Configuration.GetSection("MiniProgress");
            var Response = Http.HttpRequest(Configuration["Url"]+Code);
            return Task.Run(()=> {
                return Response;
            });
        }

        public async Task<User> FindUserByUserOpenId(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                throw new ArgumentNullException(nameof(Id));

            var Result = await this.Server.FindAsync(d=>d.UserId == Id);
            return Result.First();
        }
    }
}
