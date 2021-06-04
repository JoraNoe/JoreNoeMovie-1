using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.TimerServices;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace JoreNoeVideo.DomainServices
{
    public class MovieDomainService : IMoviceDomainService
    {
        public MovieDomainService(IDbContextFace<Movie> Server,
            IHttpRequestDomainService HttpRequestDomainService,
            IConfiguration Configuration,
            IUserLikeMovieDomainService UserLikeMovieService)
        {
            this.Server = Server;
            this.Configuration = Configuration;
            this.UserLikeMovieService = UserLikeMovieService;
            this.HttpRequestDomainService = HttpRequestDomainService;
        }
        private readonly IConfiguration Configuration;
        private readonly IHttpRequestDomainService HttpRequestDomainService;
        private readonly IUserLikeMovieDomainService UserLikeMovieService;
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


        /// <summary>
        /// 喜欢
        /// </summary>
        /// <param name="影片ID"></param>
        /// <returns></returns>
        public async Task<int> AddLike(Guid Id, Guid MovieId)
        {
            //判断当前用户是否点过赞  

            var Exists = await this.UserLikeMovieService.Exists(Id, MovieId);
            if (Exists)
                return -2;
            _ = await UserLikeMovieService.CreateUserLikeMovie(Id, MovieId);
            //查询当前影片喜欢数量
            var Single = await this.Server.GetSingle(Id).ConfigureAwait(false);
            Single.Likes += 1;
            //修改
            await this.Server.EditAsync(Single);

            return Single.Likes;
        }

        /// <summary>
        /// 不喜欢
        /// </summary>
        /// <param name="影片ID"></param>
        /// <returns></returns>
        public async Task<int> AddDisLike(Guid Id, Guid MovieId)
        {
            var Exists = await this.UserLikeMovieService.Exists(Id, MovieId);
            if (Exists)
                return -1;
            _ = await UserLikeMovieService.CreateUserLikeMovie(Id, MovieId);
            //查询当前影片喜欢数量
            var Single = await this.Server.GetSingle(Id).ConfigureAwait(false);
            Single.DisLikes += 1;
            //修改
            await this.Server.EditAsync(Single);

            return Single.Likes;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="SearchMovieName"></param>
        /// <returns></returns>
        public async Task<IList<Movie>> SearchMovie(string SearchMovieName)
        {
            var DbResult = await this.Server.FindAsync(d => d.MovieName.Contains(SearchMovieName));
            if (DbResult == null || DbResult.Count == 0)
            {
                //请求外界  
                var RequestHTML = await this.HttpRequestDomainService.HttpRequest(this.Configuration.GetSection("MovieUrls")["SearchUrl"].ToString());
                //拆解 HTML  获取数据 -- 未完
                return null;
            }
            else
            {
                return DbResult;
            }
        }
    }
}
