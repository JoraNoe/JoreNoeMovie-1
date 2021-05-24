using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public class SystemIconDomainService : ISystemIconDomainService
    {
        private readonly IDbContextFace<SystemIcon> server;
        public SystemIconDomainService(IDbContextFace<SystemIcon> server)
        {
            this.server = server;
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SystemIcon> CreateSystemIcon(SystemIcon model)
        {
            return await this.server.AddAsync(model).ConfigureAwait(false);
        }

        //public async Task<SystemIcon> CreateOrEditSystemIcon(SystemIcon model)
        //{
        //    var Item = this.server.GetSingle(model.Id);
        //    if(Item)
        //}

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SystemIcon> EditSystemIcon(SystemIcon model)
        {
            return await this.server.EditAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<SystemIcon> SingleSystemIcon(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
