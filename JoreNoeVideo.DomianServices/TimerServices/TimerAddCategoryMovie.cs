﻿using HtmlAgilityPack;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.Tools;
using JoreNoeVideo.Store;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices.TimerServices
{
    public class TimerAddCategoryMovie : IJob
    {
        private static StringBuilder Message = new StringBuilder("开始抓取影视分类中的视频数据");

        private static IList<Movie> InsertData = new List<Movie>();

        private static IHttpRequestDomainService HttpRequestDomain = RelitClass.HttpRequestDomain;

        private string BaseUrl = string.Empty;

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("开始爬取影视分类中视频数据");
            await Task.Run(async () =>
            {
                InsertData.Clear();

                var jobData = context.JobDetail.JobDataMap;//获取Job中的参数
                string Url = jobData.GetString("Url");
                this.BaseUrl = jobData.GetString("BaseUrl");
                // 将数据全部导入 Movie
                DbContextFace<MovieCategory> MovieCategoryService = new DbContextFace<MovieCategory>();
                var CategoryInfos = MovieCategoryService.All().OrderBy(d => d.OrderBy).ToList();

                foreach (var SingleCategory in CategoryInfos)
                {
                    var DocumentHtml = await HttpRequestDomain.HttpRequest(SingleCategory.CategoryUrl);
                    HtmlDocument html = new HtmlDocument();
                    html.LoadHtml(DocumentHtml);
                    if (string.IsNullOrEmpty(DocumentHtml))
                        continue;

                    var DataNode = html.DocumentNode.SelectSingleNode("//div[@class='box-b2-l6 fn-clear']").ChildNodes[0].ChildNodes;
                    if (DataNode.Count == 0)
                        continue;
                    //读取链接 
                    foreach (var item in DataNode)
                    {
                        InsertData.Add(new Movie
                        {
                            MovieCategoryId = SingleCategory.Id.ToString(),
                            MovieName = item.ChildNodes[1].ChildNodes[0].InnerText,
                            MovieCategory = SingleCategory.CategoryName,
                            MovieDesc = item.ChildNodes[1].ChildNodes[1].InnerText,
                            MovieImgUrl = item.ChildNodes[0].ChildNodes[0].Attributes["src"].Value.ToString(),
                            MovieLink = BaseUrl + item.ChildNodes[0].Attributes["href"].Value.ToString(),
                            MovieTitle = ""//RelitClass.JudgeMovieDefinition(item.ChildNodes[0].ChildNodes[2].InnerText.ToString()),
                        });
                    }
                    Message.Append(SingleCategory.CategoryName + "数据爬取成功" + "爬取时间：" + DateTime.Now);
                }
                for (int i = 0; i < InsertData.Count; i++)
                {
                    await this.HttpRequestDescption(i,InsertData[i].MovieLink);
                }

                // 将数据全部导入 Movie
                DbContextFace<Movie> MovieService = new DbContextFace<Movie>();
                //处理名称
                var HttpWebRequestArray = InsertData.Select(d => d.MovieName).ToArray();

                var FindMovieService = MovieService.Find(d => HttpWebRequestArray.Contains(d.MovieName));

                if (FindMovieService == null || FindMovieService.Count == 0)
                {
                    //插入数据
                    MovieService.AddRange(InsertData);
                    Message.Append("\n数据库数据为空，添加数据成功！");
                }
                else
                {
                    //筛选不重复数据
                    var DisctinDataMovieList = InsertData.Where(d => !FindMovieService.
                    Select(d => d.MovieName).ToArray().Contains(d.MovieName)).ToList();
                    //添加数据
                    MovieService.AddRange(DisctinDataMovieList);
                    Message.Append("\n重新添加数据成功！");
                }

                //日志写入
                LogStreamWrite.WriteLineLog(Message.ToString());

            });
        }

        public async Task HttpRequestDescption(int i,string Url)
        {
            //读取详情内容

            var TempUrl = InsertData[i].MovieLink;
            var DesctionHTML = await HttpRequestDomain.HttpRequest(Url);
            //如果为空 从新 抓取 
            if (string.IsNullOrEmpty(DesctionHTML))
            {
                //重新执行
                await this.HttpRequestDescption(i, Url);
            }
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
                Address = DesctionNode.ChildNodes[4].ChildNodes[0].FirstChild.NextSibling == null ? "" : DesctionNode.ChildNodes[4].ChildNodes[0].FirstChild.NextSibling.InnerText,
                Year = DesctionNode.ChildNodes[4].ChildNodes[1].FirstChild.NextSibling == null ? "" : DesctionNode.ChildNodes[4].ChildNodes[1].FirstChild.NextSibling.InnerText,
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
                    ColletionName = RelitClass.JudgeMovieDefinition(item.Attributes["title"].Value.ToString()),
                    Link = BaseUrl + item.Attributes["href"].Value.ToString(),
                    MovieId = InsertData[i].Id.ToString()
                });
            }
            Thread.Sleep(100);
            Console.WriteLine(i + "-" + InsertData[i].MovieLink);

        }

    }
}
