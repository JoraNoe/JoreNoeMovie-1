﻿using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public class MovieMindCollectionsDomainService : IMovieMindCollectionsDomainService
    {
        private readonly IDbContextFace<MovieMindCollections> server;
        public MovieMindCollectionsDomainService(IDbContextFace<MovieMindCollections> service)
        {
            this.server = service;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieMindCollections> AddMovieMindCollections(MovieMindCollections model)
        {
            return await this.server.AddAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IList<MovieMindCollections>> AllMovieMindCollections()
        {
            return await this.server.AllAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieMindCollections> EditMovieMindCollections(MovieMindCollections model)
        {
            return await this.server.EditAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<MovieMindCollections>> Pagin(int PageNum, int PageSize)
        {
            return await this.server.Page(PageNum, PageSize);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<MovieMindCollections> RemovedMovieMindCollections(Guid Id)
        {
            return await this.server.DeleteAsync(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<MovieMindCollections> SingleMovieMindCollections(Guid Id)
        {
            return await this.server.GetSingle(Id).ConfigureAwait(false);
        }
    }
}
