using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.TimerServices;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using JoreNoeVideo.Cache;
using Newtonsoft.Json;
using StackExchange.Redis;
using HtmlAgilityPack;
using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.DomainServices.Tools;

namespace JoreNoeVideo.DomainServices
{
    public class MovieDomainService : IMoviceDomainService
    {
        public MovieDomainService(IDbContextFace<Movie> Server,
            IHttpRequestDomainService HttpRequestDomainService,
            IConfiguration Configuration,
            IRedisCache RedisCache,
            IUserLikeMovieDomainService UserLikeMovieService)
        {
            this.Server = Server;
            this.Configuration = Configuration;
            this.UserLikeMovieService = UserLikeMovieService;
            this.HttpRequestDomainService = HttpRequestDomainService;
            this.RedisCache = RedisCache.GetDatabase();
        }
        /// <summary>
        /// 配置文件
        /// </summary>
        private readonly IConfiguration Configuration;
        /// <summary>
        /// HTTP请求
        /// </summary>
        private readonly IHttpRequestDomainService HttpRequestDomainService;
        /// <summary>
        /// 用户喜欢
        /// </summary>
        private readonly IUserLikeMovieDomainService UserLikeMovieService;
        /// <summary>
        /// DB服务
        /// </summary>
        private readonly IDbContextFace<Movie> Server;
        /// <summary>
        /// 缓存
        /// </summary>
        private readonly IDatabase RedisCache;

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
            string CacheKey = "MovieIndexList";

            if (await this.RedisCache.KeyExistsAsync(CacheKey))
                return JsonConvert.DeserializeObject<IList<Movie>>(await this.RedisCache.StringGetAsync(CacheKey));

            //获取数据
            IList<Movie> FindIndexMovies = await this.Server.FindAsync(d => d.MovieCategory == Movie.MOVIE_CATEGORY_INDEX);


            //缓存数据
            await this.RedisCache.StringGetSetAsync(CacheKey, JsonConvert.SerializeObject(FindIndexMovies.OrderBy(d => d.OrderBy)));

            //筛选数据  frps
            //获取过期时间 
            var ExpiryTime = this.Configuration.GetSection("RedisConfig")["MinuteExpiry"];
            //转换时间 类型   设置过期时间
            var DateExpiry = TimeSpan.FromMinutes(double.Parse(ExpiryTime.ToString()));
            await this.RedisCache.KeyExpireAsync(CacheKey, DateExpiry);

            return FindIndexMovies.OrderBy(d => d.OrderBy).ToList();
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
            var Single = await this.Server.GetSingle(MovieId).ConfigureAwait(false);
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
        /// <param name="PageIndex">当前页面</param>
        /// <returns></returns>
        public async Task<APIReturnInfo<IList<Movie>>> SearchMovie(string SearchMovieName, int PageIndex = 0)
        {

            if (string.IsNullOrEmpty(SearchMovieName))
                return APIReturnInfo<IList<Movie>>.Error("无法搜索空内容");

            string CacheKey = string.Concat("Movie_Search_List_Name_", SearchMovieName, "_CurrentPage_", PageIndex);

            //查询Redis 是否存在数据
            if (await this.RedisCache.KeyExistsAsync(CacheKey))
                return APIReturnInfo<IList<Movie>>.Success(JsonConvert.DeserializeObject<IList<Movie>>(await this.RedisCache.StringGetAsync(CacheKey)));

            //获取请求网关 
            string BaseUrl = this.Configuration.GetSection("MovieUrls")["BaseUrl"].ToString();
            //请求外界  
            var RequestHTML = await this.HttpRequestDomainService.HttpRequest(this.Configuration.GetSection("MovieUrls")["SearchUrl"].ToString() + "?wd=" + SearchMovieName);
            //拆解 HTML  获取数据 -- 未完
            //serach-ul
            HtmlDocument DectionDocument = new HtmlDocument();
            DectionDocument.LoadHtml(RequestHTML);
            //拆解信息
            var DesctionNode = DectionDocument.DocumentNode.SelectSingleNode("//ul[@class='serach-ul']");

            IList<Movie> MovieInfos = new List<Movie>();

            foreach (var item in DesctionNode.ChildNodes)
            {
                MovieInfos.Add(new Movie
                {
                    DisLikes = 0,
                    Likes = 0,
                    MovieCategory = Movie.MOVIE_CATEGORY_SEARCH,
                    MovieImgUrl = item.FirstChild.FirstChild.Attributes["src"].Value.ToString(),
                    MovieLink = BaseUrl + item.FirstChild.Attributes["href"].Value.ToString(),
                    MovieName = item.FirstChild.Attributes["title"].Value.ToString(),
                });
            }

            //爬取详情数据 
            foreach (var item in MovieInfos)
            {
                var DesctionHTML = await this.HttpRequestDomainService.HttpRequest(item.MovieLink);
                HtmlDocument ItemDectionDocument = new HtmlDocument();
                ItemDectionDocument.LoadHtml(DesctionHTML);
                //拆解信息
                var ItemDesctionNode = ItemDectionDocument.DocumentNode.SelectSingleNode("//div[@class='fd-box']");
                var Index = ItemDesctionNode.ChildNodes[4].ChildNodes[2].InnerText.IndexOf("：") + 1;
                //读取信息
                item.MovieDesction = new MovieDesc
                {
                    Director = ItemDesctionNode.ChildNodes[2].ChildNodes[1].FirstChild.NextSibling == null
                    ? ItemDesctionNode.ChildNodes[2].ChildNodes[1].FirstChild.InnerText :
                    ItemDesctionNode.ChildNodes[2].ChildNodes[1].FirstChild.NextSibling.InnerText,
                    Describe = ItemDesctionNode.ChildNodes[6].ChildNodes[0].FirstChild.InnerText,
                    Address = ItemDesctionNode.ChildNodes[4].ChildNodes[0].FirstChild.NextSibling == null ? "" : ItemDesctionNode.ChildNodes[4].ChildNodes[0].FirstChild.NextSibling.InnerText,
                    Year = ItemDesctionNode.ChildNodes[4].ChildNodes[1].FirstChild.NextSibling == null ? "" : ItemDesctionNode.ChildNodes[4].ChildNodes[1].FirstChild.NextSibling.InnerText,
                    UpdateTime = DateTime.Parse(ItemDesctionNode.ChildNodes[4].ChildNodes[2].InnerText.Substring(
                    Index, ItemDesctionNode.ChildNodes[4].ChildNodes[2].InnerText.Length - Index) ?? ""),
                    MovieId = item.Id.ToString(),

                };

                //读取主演
                item.MovieDesction.MainDirector = ItemDesctionNode.ChildNodes[3].FirstChild.InnerText;

                //读取影片集数 
                var Collections = ItemDectionDocument.DocumentNode.SelectNodes("//div[@class='lv-bf-list']//a");

                item.MovieDesction.MovieCollections = new List<MovieCollections>();
                foreach (var SingleCollection in Collections)
                {
                    item.MovieDesction.MovieCollections.Add(new MovieCollections
                    {
                        ColletionName = RelitClass.JudgeMovieDefinition(SingleCollection.Attributes["title"].Value.ToString()),
                        Link = BaseUrl + SingleCollection.Attributes["href"].Value.ToString(),
                        MovieId = item.Id.ToString()
                    });
                }
            }

            if (MovieInfos.Count != 0)
            {
                var SaveInfos = await this.Server.AddRangeAsync(MovieInfos);
                //保存 Redis  
                this.RedisCache.StringSet(CacheKey, JsonConvert.SerializeObject(SaveInfos));
            }

            return APIReturnInfo<IList<Movie>>.Success(MovieInfos);
        }

        /// <summary>
        /// 根据影视类型查看全部影视信息
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public async Task<IList<Movie>> FindMovieByMovieCategoryId(string CategoryId)
        {
            if (string.IsNullOrEmpty(CategoryId))
                throw new ArgumentNullException(nameof(CategoryId));
            //写入缓存
            string RedisCacheKey = string.Concat("MovieCategory_List_CategoryId_", CategoryId);

            if (!await this.RedisCache.KeyExistsAsync(RedisCacheKey))
            {
                var FindMovieByCategoryInfos = this.Server.Find(d => d.MovieCategoryId == CategoryId);
                //缓存中
                this.RedisCache.StringSet(RedisCacheKey, JsonConvert.SerializeObject(FindMovieByCategoryInfos));
            }
            return JsonConvert.DeserializeObject<IList<Movie>>(await this.RedisCache.StringGetAsync(RedisCacheKey));
        }
    }
}
