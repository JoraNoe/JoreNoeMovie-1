﻿using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.TimerServices;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public class MovieDomainService : IMoviceDomainService
    {
        public MovieDomainService(IDbContextFace<Movie> Server)
        {
            this.Server = Server;
        }
        private readonly IDbContextFace<Movie> Server;
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public async Task<Movie> AddMovie(Movie Model)
        {
            return await this.Server.AddAsync(Model).ConfigureAwait(false);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Movie>> AllMovie()
        {
            return await this.Server.AllAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public async Task<Movie> EditMovie(Movie Model)
        {
            return await this.Server.EditAsync(Model).ConfigureAwait(false);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<Movie>> Pagin(int PageNum, int PageSize)
        {
            return await this.Server.Page(PageNum, PageSize).ConfigureAwait(false);
        }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Movie> RemoveMovie(Guid Id)
        {
            return await this.Server.DeleteAsync(Id).ConfigureAwait(false);
        }
        /// <summary>
        ///  单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Movie> SingleMovie(Guid Id)
        {
            return await this.Server.GetSingle(Id).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        public async Task<IList<Movie>> FindByMovieIdsMovie(Guid[] MovieIds)
        {
            return await this.Server.FindAsync(d => MovieIds.ToString().Contains(d.Id.ToString()));

        }
        /// <summary>
        /// 获取首页视频
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Movie>> GetIndexMovie()
        {
            //筛选数据 
            var Result = await this.Server.FindAsync(d => d.MovieName.Contains(ConstVariables.CONST_INDEXNAME));
            for (int i = 0; i < Result.Count; i++)
            {
                var temp = Result[i].MovieName;
                Result[i].MovieName = Result[i].MovieName.Substring(0, temp.IndexOf('-'));
            }
            return Result;
        }
    }
}
