using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public class AnimationOperaDomainService : IAnimationOperaDomainService
    {
        private readonly IDbContextFace<AnimationOpera> server;
        public AnimationOperaDomainService(IDbContextFace<AnimationOpera> server)
        {
            this.server = server;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IList<AnimationOpera>> AllAnimationOpera()
        {
            return await this.server.AllAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<AnimationOpera> CreateAnimationOpera(AnimationOpera model)
        {
            return await this.server.AddAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<AnimationOpera> EditAnimationOpera(AnimationOpera model)
        {
            return await this.server.EditAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<AnimationOpera>> Pagein(int PageNum, int PageSize)
        {
            return await this.server.Page(PageNum, PageSize).ConfigureAwait(false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<AnimationOpera> RemovedAnimationOpera(Guid Id)
        {
            return await this.server.DeleteAsync(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 单个查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<AnimationOpera> SingleAnimationOpera(Guid Id)
        {
            return await this.server.GetSingle(Id).ConfigureAwait(false);
        }
    }
}
