using HtmlAgilityPack;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.Tools;
using JoreNoeVideo.Store;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices.TimerServices
{
    /// <summary>
    /// 爬取电影分类
    /// </summary>
    public class TimerAddMovieCategory : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("开始爬取影视分类数据");
            await Task.Run(async () =>
            {
                var HttpRequestDomain = RelitClass.HttpRequestDomain;
                var jobData = context.JobDetail.JobDataMap;//获取Job中的参数
                string Url = jobData.GetString("Url");
                string BaseUrl = jobData.GetString("BaseUrl");
                string Message = "开始请求数据";
                var DocumentHtml = await HttpRequestDomain.HttpRequest(Url);
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(DocumentHtml);
                var DataNode = html.DocumentNode.SelectSingleNode("//div[@class='all-type-layout']");
                //获取数据
                var InsertData = new List<MovieCategory>();
                //获取单个数据
                var SingleHtmlData = DataNode.ChildNodes[1].ChildNodes[1];

                for (int i = 0; i < SingleHtmlData.ChildNodes.Count; i++)
                {
                    InsertData.Add(new MovieCategory
                    {
                        CategoryName = SingleHtmlData.ChildNodes[i].InnerText,
                        CreateTime = DateTime.Now,
                        Id = Guid.NewGuid(),
                        CategoryUrl = BaseUrl + SingleHtmlData.ChildNodes[i].Attributes["href"].Value.ToString().Trim(),
                        OrderBy = i
                    });
                }

                // 将数据全部导入 Movie
                DbContextFace<MovieCategory> MovieService = new DbContextFace<MovieCategory>();
                if(MovieService.Find(d=>true).Count == 0)
                {
                    await MovieService.AddRangeAsync(InsertData);
                    //写入日志 
                    LogStreamWrite.WriteLineLog(Message);
                }
            });
        }
    }
}
