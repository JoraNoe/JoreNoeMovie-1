using HtmlAgilityPack;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.Tools;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using JoreNoeVideo.Abstractions.Values;

namespace JoreNoeVideo.DomainServices
{
    public class MovieCollectionsDomainService : IMovieCollectionsDomainService
    {
        private readonly IDbContextFace<Domain.Models.MovieCollections> server;
        private readonly IHttpRequestDomainService HttpRequestDomain = RelitClass.HttpRequestDomain;
        public MovieCollectionsDomainService(IDbContextFace<Domain.Models.MovieCollections> server)
        {
            this.server = server;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Domain.Models.MovieCollections> AddMovieCollections(Domain.Models.MovieCollections model)
        {
            return await this.server.AddAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Domain.Models.MovieCollections>> AllMovieCollections()
        {
            return await this.server.AllAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Domain.Models.MovieCollections> EditMovieCollections(Domain.Models.MovieCollections model)
        {
            return await this.server.EditAsync(model).ConfigureAwait(false);
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<Domain.Models.MovieCollections>> Pagin(int PageNum, int PageSize)
        {
            return await this.Pagin(PageNum, PageSize).ConfigureAwait(false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Domain.Models.MovieCollections> RemovedMovieCollections(Guid Id)
        {
            return await this.server.DeleteAsync(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Domain.Models.MovieCollections> SingleMovieCollections(Guid Id)
        {
            return await this.server.GetSingle(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 根据视频ID查询当前视频的集数
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        public async Task<IList<MovieCollectionValue>> FindCollectionByMovieId(Guid MovieId)
        {
            //筛选
            var CurrentMovieCollection = await this.server.FindAsync(d => d.MovieId == MovieId.ToString()).ConfigureAwait(false);

            var IsJudge = false;
            IList<KeyValuePair<string, string>> Data = CurrentMovieCollection.Select(d =>
            new KeyValuePair<string, string>(d.Id.ToString(),
                 RelitClass.removeNotNumber(d.ColletionName, out IsJudge))).ToList();

            //二重判断 
            foreach (var item in Data)
            {
                RelitClass.removeNotNumber(item.Value, out IsJudge);
                if (IsJudge == false)
                {
                    IsJudge = false;
                    break;
                }
            }

            var Temp = new List<MovieCollectionValue>();
            if (IsJudge)
            {
                var OrderByData = Data.OrderBy(d => d.Value).ToList();
                //获取最大值 
                var Max = OrderByData.Max(d => int.Parse(d.Value));

                //判断超过  六位数 
                if(Max.ToString().Length <= 5)
                {
                    var IndexCount = OrderByData.Where(d => int.Parse(d.Value) == Max).Count();

                    for (int i = 1; i <= Max; i++)
                    {
                        var WhereData = OrderByData.Where(d => int.Parse(d.Value) == i).Select(d => d.Key).ToList();

                        Temp.AddRange(CurrentMovieCollection.Where(d => WhereData.Contains(d.Id.ToString())).Select((d, s) => new MovieCollectionValue
                        {
                            ColletionName = d.ColletionName,
                            Id = d.Id,
                            Link = d.Link,
                            ModelType = s,
                            MovieId = d.MovieId,
                            PlayerLink = d.PlayerLink,
                            Index = IndexCount
                        }));
                    }
                }
                else
                {
                    foreach (var d in CurrentMovieCollection)
                    {
                        Temp.Add(new MovieCollectionValue
                        {
                            ColletionName = d.ColletionName,
                            Id = d.Id,
                            Link = d.Link,
                            ModelType = 0,
                            MovieId = d.MovieId,
                            PlayerLink = d.PlayerLink,
                            Index = 0
                        });
                    }
                }

                
            }
            else
            {
                var i = 0;
                foreach (var d in CurrentMovieCollection)
                {
                    Temp.Add(new MovieCollectionValue
                    {
                        ColletionName = d.ColletionName,
                        Id = d.Id,
                        Link = d.Link,
                        ModelType = i,
                        MovieId = d.MovieId,
                        PlayerLink = d.PlayerLink,
                        Index = i
                    });
                    i++;
                }
                Temp[0].Index = i;
            }


            IList<KeyValuePair<string, string>> Sort = Temp.Select(d =>
            new KeyValuePair<string, string>(d.Id.ToString(),
                 RelitClass.removeNotNumber(d.ColletionName, out IsJudge))).ToList();


            var SortTempData = new List<MovieCollectionValue>();
            foreach (var item in Sort.OrderBy(d => d.Value).ToList())
            {
                SortTempData.Add(Temp.Where(d=>d.Id.ToString() == item.Key).SingleOrDefault());
            }


            return SortTempData;
        }

        /// <summary>
        /// 爬取视频播放地址
        /// </summary>
        /// <param name="CollectionId"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public async Task<Domain.Models.MovieCollections> SinglePlayerAddress(Guid CollectionId, string Path)
        {
            //判断数据库是否存在词条数据
            var Single = await this.server.GetSingle(CollectionId);
            if (Single != null && Single.PlayerLink != null)
            {
                return Single;
            }
            else
            {
                //读取影片播放地址
                var CollectionsPlayerLinkDocument = await this.HttpRequestDomain.HttpRequest(Path);
                HtmlDocument Doc = new HtmlDocument();
                Doc.LoadHtml(CollectionsPlayerLinkDocument);
                var Nodel = Doc.DocumentNode.SelectSingleNode("//div[@class='player-ff w900']");
                string OuterHtml = Nodel.OuterHtml.ToString();
                string Assmble = OuterHtml.Substring(OuterHtml.IndexOf("url") + 6, OuterHtml.IndexOf("url_next") - 11).Split("url_next")[0];
                string CompleUrl = Assmble.Split(",")[0];
                char Split = '"';
                //"https://api.yktvb.com/dplayer3.html?url="
                string PlayerUrl = CompleUrl.Replace("\\", "").Replace($"{Split}", "");
                //保存数据
                Single.PlayerLink = PlayerUrl;
                await this.server.EditAsync(Single);
                return Single;
            }
        }






    }
}
