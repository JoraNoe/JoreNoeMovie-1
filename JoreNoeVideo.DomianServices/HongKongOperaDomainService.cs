using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public class HongKongOperaDomainService : IHongKongOperaDomainService
    {
        private readonly IDbContextFace<HongKongOpera> server;
        public HongKongOperaDomainService(IDbContextFace<HongKongOpera> server)
        {
            this.server = server;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IList<HongKongOpera>> AllHongKongOpera()
        {
            return await this.server.AllAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<HongKongOpera> CreateHongKongOpera(HongKongOpera model)
        {
            return await this.server.AddAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<HongKongOpera> EditHongKongOpera(HongKongOpera model)
        {
            return await this.server.EditAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<HongKongOpera>> Pagin(int PageNum, int PageSize)
        {
            return await this.server.Page(PageNum, PageSize).ConfigureAwait(false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<HongKongOpera> RemovedHongKongOpera(Guid Id)
        {
            return await this.server.DeleteAsync(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<HongKongOpera> SingleHongKongOpera(Guid Id)
        {
            return await this.server.GetSingle(Id).ConfigureAwait(false);
        }
    }
}
