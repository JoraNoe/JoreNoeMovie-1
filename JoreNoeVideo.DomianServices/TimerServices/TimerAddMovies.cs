using HtmlAgilityPack;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.Tools;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using JoreNoeVideo.Domain;
using JoreNoeVideo.Store;

namespace JoreNoeVideo.DomainServices.TimerServices
{
    /// <summary>
    /// 最新影视 定时 爬取网站数据
    /// </summary>
    public class TimerAddMovies : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine(context.ToString());
            await Task.Run(async () =>
            {
                var HttpRequestDomain = RelitClass.HttpRequestDomain;
                var jobData = context.JobDetail.JobDataMap;//获取Job中的参数
                string Url = jobData.GetString("Url");
                string Message = "开始请求数据";
                var DocumentHtml = await HttpRequestDomain.HttpRequest(Url);
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(DocumentHtml);
                var DataNode = html.DocumentNode.SelectNodes("//div[@class='box-model-cont fn-clear']");
                var InsertData = new List<Movie>();
                //读取链接 
                foreach (var item in DataNode)
                {
                    foreach (var itemSon in item.ChildNodes)
                    {
                        InsertData.Add(new Movie
                        {
                            MovieName = itemSon.ChildNodes[1].ChildNodes[0].InnerText + ConstVariables.CONST_INDEXNAME,
                            MovieDesc = itemSon.ChildNodes[1].ChildNodes[1].InnerText,
                            MovieImgUrl = itemSon.ChildNodes[0].ChildNodes[0].Attributes["src"].Value.ToString(),
                            MovieLink = Url + itemSon.Attributes["href"].Value.ToString(),
                            MovieTitle = this.JudgeMovieDefinition(itemSon.ChildNodes[0].ChildNodes[2].InnerText.ToString()),
                        });
                    }
                }

                //读取详情内容
                for (int i = 0; i < InsertData.Count; i++)
                {
                    var TempInsert = InsertData[i];

                    var DesctionHTML = await HttpRequestDomain.HttpRequest(TempInsert.MovieLink);
                    HtmlDocument DectionDocument = new HtmlDocument();
                    DectionDocument.LoadHtml(DesctionHTML);
                    //拆解信息
                    var DesctionNode = DectionDocument.DocumentNode.SelectSingleNode("//div[@class='fd-box']");
                    var Index = DesctionNode.ChildNodes[4].ChildNodes[2].InnerText.IndexOf("：") + 1;
                    //读取信息
                    InsertData[i].MovieDesction = new MovieDesc
                    {
                        Director = DesctionNode.ChildNodes[2].ChildNodes[1].FirstChild.NextSibling == null
                        ? DesctionNode.ChildNodes[2].ChildNodes[1].FirstChild.InnerText :
                        DesctionNode.ChildNodes[2].ChildNodes[1].FirstChild.NextSibling.InnerText,
                        Describe = DesctionNode.ChildNodes[6].ChildNodes[0].FirstChild.InnerText,
                        Address = DesctionNode.ChildNodes[4].ChildNodes[0].FirstChild.NextSibling.InnerText,
                        Year = DesctionNode.ChildNodes[4].ChildNodes[1].FirstChild.NextSibling.InnerText,
                        UpdateTime = DateTime.Parse(DesctionNode.ChildNodes[4].ChildNodes[2].InnerText.Substring(
                          Index, DesctionNode.ChildNodes[4].ChildNodes[2].InnerText.Length - Index) ?? ""),
                        MovieId = InsertData[i].Id.ToString(),
                    };

                    //读取主演
                    InsertData[i].MovieDesction.MainDirector = DesctionNode.ChildNodes[3].FirstChild.InnerText;

                    //读取影片集数 
                    var Collections = DectionDocument.DocumentNode.SelectNodes("//div[@class='lv-bf-list']//a");
                    InsertData[i].MovieDesction.MovieCollections = new List<MovieCollections>();
                    foreach (var item in Collections)
                    {
                        InsertData[i].MovieDesction.MovieCollections.Add(new MovieCollections
                        {
                            ColletionName = this.JudgeMovieDefinition(item.Attributes["title"].Value.ToString()),
                            Link = Url + item.Attributes["href"].Value.ToString(),
                            MovieId = InsertData[i].Id.ToString(),
                        });
                    }
                }


                #region 注释
                //////验证是否一致数据  -- 存入 推荐电影
                ////DbContextFace<NewestMovie> NewestServer = new DbContextFace<NewestMovie>();
                ////var mapList = NewestServer.All();
                ////if (mapList == null || mapList.Count == 0)
                ////{
                ////    NewestServer.AddRange(InsertData.Take(10).ToList());
                ////    Message += "旧数据库数据为空 -- 插入成功 -- 推荐 /n";
                ////}
                ////else
                ////{
                ////    foreach (var item in mapList)
                ////    {
                ////        //清空数据
                ////        NewestServer.Delete(item.Id);
                ////        Message += "数据清楚成功 -- 推荐！/n";
                ////    }
                ////    //插入数据
                ////    NewestServer.AddRange(InsertData.Take(10).ToList());
                ////    Message += "数据添加成功 -- 推荐 \n";
                ////}
                //////存入 电影
                ////DbContextFace<FilmOpera> FilmService = new DbContextFace<FilmOpera>();
                ////var FilmOperaList = FilmService.All();
                ////List<FilmOpera> FilmOpra = InsertData.Skip(10).Take(20).ToList().Select(d => new FilmOpera
                ////{
                ////    MovieName = d.MovieName,
                ////    MovieDesc = d.MovieDesc,
                ////    MovieImgUrl = d.MovieImgUrl,
                ////    MovieLink = d.MovieLink,
                ////    MovieTitle = this.JudgeMovieDefinition(d.MovieTitle)
                ////}).ToList();
                ////if (FilmOperaList == null || FilmOperaList.Count == 0)
                ////{
                ////    FilmService.AddRange(FilmOpra);
                ////    Message += "旧数据库数据为空 -- 插入成功 -- 电影/n";
                ////}
                ////else
                ////{
                ////    foreach (var item in FilmOperaList)
                ////    {
                ////        //清空数据
                ////        FilmService.Delete(item.Id);
                ////        Message += "数据清楚成功 -- 电影！/n";
                ////    }
                ////    //插入数据
                ////    FilmService.AddRange(FilmOpra);
                ////    Message += "数据添加成功 -- 电影 /n";
                ////}



                ////// 存入 大陆剧
                ////DbContextFace<MainlandOpera> MainLandServer = new DbContextFace<MainlandOpera>();
                ////var MainLandList = MainLandServer.All();
                ////List<MainlandOpera> MainLandOpera = InsertData.Skip(20).Take(30).ToList().Select(d => new MainlandOpera
                ////{
                ////    MovieName = d.MovieName,
                ////    MovieDesc = d.MovieDesc,
                ////    MovieImgUrl = d.MovieImgUrl,
                ////    MovieLink = d.MovieLink,
                ////    MovieTitle = this.JudgeMovieDefinition(d.MovieTitle)
                ////}).ToList();
                ////if (MainLandList == null || MainLandList.Count == 0)
                ////{
                ////    MainLandServer.AddRange(MainLandOpera);
                ////    Message += "旧数据库数据为空 -- 插入成功 -- 大陆剧/n";
                ////}
                ////else
                ////{
                ////    foreach (var item in MainLandList)
                ////    {
                ////        //清空数据
                ////        MainLandServer.Delete(item.Id);
                ////        Message += "数据清楚成功 -- 大陆剧！/n";
                ////    }
                ////    //插入数据
                ////    MainLandServer.AddRange(MainLandOpera);
                ////    Message += "数据添加成功 -- 大陆剧 /n";
                ////}


                ////// 存入 港剧
                ////DbContextFace<HongKongOpera> HongKongService = new DbContextFace<HongKongOpera>();
                ////var HongKongList = HongKongService.All();
                ////List<HongKongOpera> HongKongOpera = InsertData.Skip(30).Take(40).ToList().Select(d => new HongKongOpera
                ////{
                ////    MovieName = d.MovieName,
                ////    MovieDesc = d.MovieDesc,
                ////    MovieImgUrl = d.MovieImgUrl,
                ////    MovieLink = d.MovieLink,
                ////    MovieTitle = this.JudgeMovieDefinition(d.MovieTitle)
                ////}).ToList();
                ////if (HongKongList == null || HongKongList.Count == 0)
                ////{
                ////    HongKongService.AddRange(HongKongOpera);
                ////    Message += "旧数据库数据为空 -- 插入成功 -- 港剧/n";
                ////}
                ////else
                ////{
                ////    foreach (var item in HongKongList)
                ////    {
                ////        //清空数据
                ////        HongKongService.Delete(item.Id);
                ////        Message += "数据清楚成功 -- 港剧！/n";
                ////    }
                ////    //插入数据
                ////    HongKongService.AddRange(HongKongOpera);
                ////    Message += "数据添加成功 -- 港剧 /n";
                ////}



                ////// 存入 韩剧
                ////DbContextFace<KoreanDramaOpera> KoreanDramaService = new DbContextFace<KoreanDramaOpera>();
                ////var KoreanDramaList = KoreanDramaService.All();
                ////List<KoreanDramaOpera> KoreanDramaOpera = InsertData.Skip(40).Take(50).ToList().Select(d => new KoreanDramaOpera
                ////{
                ////    MovieName = d.MovieName,
                ////    MovieDesc = d.MovieDesc,
                ////    MovieImgUrl = d.MovieImgUrl,
                ////    MovieLink = d.MovieLink,
                ////    MovieTitle = this.JudgeMovieDefinition(d.MovieTitle)
                ////}).ToList();
                ////if (KoreanDramaList == null || KoreanDramaList.Count == 0)
                ////{
                ////    KoreanDramaService.AddRange(KoreanDramaOpera);
                ////    Message += "旧数据库数据为空 -- 插入成功 -- 韩剧/n";
                ////}
                ////else
                ////{
                ////    foreach (var item in HongKongList)
                ////    {
                ////        //清空数据
                ////        KoreanDramaService.Delete(item.Id);
                ////        Message += "数据清楚成功 -- 韩剧！/n";
                ////    }
                ////    //插入数据
                ////    KoreanDramaService.AddRange(KoreanDramaOpera);
                ////    Message += "数据添加成功 -- 韩剧 /n";
                ////}



                ////// 存入 美剧
                ////DbContextFace<AmericanOpera> AmericanOperaService = new DbContextFace<AmericanOpera>();
                ////var AmericanOperaList = AmericanOperaService.All();
                ////List<AmericanOpera> AmericanOpera = InsertData.Skip(50).Take(60).ToList().Select(d => new AmericanOpera
                ////{
                ////    MovieName = d.MovieName,
                ////    MovieDesc = d.MovieDesc,
                ////    MovieImgUrl = d.MovieImgUrl,
                ////    MovieLink = d.MovieLink,
                ////    MovieTitle = this.JudgeMovieDefinition(d.MovieTitle)
                ////}).ToList();
                ////if (AmericanOperaList == null || AmericanOperaList.Count == 0)
                ////{
                ////    AmericanOperaService.AddRange(AmericanOpera);
                ////    Message += "旧数据库数据为空 -- 插入成功 -- 美剧/n";
                ////}
                ////else
                ////{
                ////    foreach (var item in AmericanOperaList)
                ////    {
                ////        //清空数据
                ////        AmericanOperaService.Delete(item.Id);
                ////        Message += "数据清楚成功 -- 美剧！/n";
                ////    }
                ////    //插入数据
                ////    AmericanOperaService.AddRange(AmericanOpera);
                ////    Message += "数据添加成功 -- 美剧 /n";
                ////}


                ////// 存入 动漫
                ////DbContextFace<AnimationOpera> AnimationOperaService = new DbContextFace<AnimationOpera>();
                ////var AnimationOperaList = AnimationOperaService.All();
                ////List<AnimationOpera> AnimationOpera = InsertData.Skip(60).Take(70).ToList().Select(d => new AnimationOpera
                ////{
                ////    MovieName = d.MovieName,
                ////    MovieDesc = d.MovieDesc,
                ////    MovieImgUrl = d.MovieImgUrl,
                ////    MovieLink = d.MovieLink,
                ////    MovieTitle = this.JudgeMovieDefinition(d.MovieTitle)
                ////}).ToList();
                ////if (AnimationOperaList == null || AnimationOperaList.Count == 0)
                ////{
                ////    AnimationOperaService.AddRange(AnimationOpera);
                ////    Message += "旧数据库数据为空 -- 插入成功 -- 动漫/n";
                ////}
                ////else
                ////{
                ////    foreach (var item in AnimationOperaList)
                ////    {
                ////        //清空数据
                ////        AnimationOperaService.Delete(item.Id);
                ////        Message += "数据清楚成功 -- 动漫！/n";
                ////    }
                ////    //插入数据
                ////    AnimationOperaService.AddRange(AnimationOpera);
                ////    Message += "数据添加成功 -- 动漫 /n";
                ////}

                #endregion


                // 将数据全部导入 Movie
                DbContextFace<Movie> MovieService = new DbContextFace<Movie>();
                //处理名称
                var HttpWebRequestArray = InsertData.Select(d => d.MovieName).ToArray();

                var FindMovieService = MovieService.Find(d => HttpWebRequestArray.Contains(d.MovieName));

                if (FindMovieService == null || FindMovieService.Count == 0)
                {
                    //插入数据
                    MovieService.AddRange(InsertData);
                    Message += "\n数据库数据为空，添加数据成功！";
                    LogStreamWrite.WriteLineLog(Message);
                }
                else
                {
                    //筛选不重复数据
                    var DisctinDataMovieList = InsertData.Where(d => !FindMovieService.
                    Select(d => d.MovieName).ToArray().Contains(d.MovieName)).ToList();
                    //添加数据
                    MovieService.AddRange(DisctinDataMovieList);
                    Message += "\n重新添加数据成功！";
                }

                //日志写入
                LogStreamWrite.WriteLineLog(Message);
            }).ConfigureAwait(false);
        }
        /// <summary>
        /// 展示类型的转换
        /// </summary>
        /// <param name="Definition">类型</param>
        /// <returns></returns>
        private string JudgeMovieDefinition(string Definition)
        {
            if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_HD)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIEHD;
            }
            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIEHD_CHINASE)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIEHDCHINAES;
            }

            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_BLUELIGHT)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIEBLUELIGHT;
            }

            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_TC)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIETC;
            }

            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_TCCHINASE)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIETCCHINASE;
            }

            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_SP)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIESP;
            }
            else if (Definition == ConstantsKey.JORENOEVIDEO_MOVIE_Hc)
            {
                return ConstantsKey.JORENOEVIDEO_MOVIEHC;
            }
            else
            {
                return Definition;
            }

        }
    }
}
