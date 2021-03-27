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
    /// 最新影视 定时
    /// </summary>
    public class TimerAddNewest: IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                var HttpRequestDomain = RelitClass.HttpRequestDomain;
                var jobData = context.JobDetail.JobDataMap;//获取Job中的参数
                string Url = jobData.GetString("Url");
                string Message = "";
                var DocumentHtml = HttpRequestDomain.HttpRequest(Url);
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(DocumentHtml);
                var DataNode = html.DocumentNode.SelectSingleNode("//div[@class='box-model-cont fn-clear']");
                var InsertData = new List<NewestMovie>();
                var FlgCount = 0;
                foreach (var item in DataNode.ChildNodes)
                {
                    //只取五条数据
                    if (FlgCount == 10)
                    {
                        break;
                    }
                    InsertData.Add(new NewestMovie
                    {
                        MovieName = item.ChildNodes[1].ChildNodes[0].InnerText,
                        MovieDesc = item.ChildNodes[1].ChildNodes[1].InnerText,
                        MovieImgUrl = item.ChildNodes[0].ChildNodes[0].Attributes["src"].Value.ToString(),
                        MovieLink = Url + item.Attributes["href"].Value.ToString(),
                        MovieTitle = item.ChildNodes[0].ChildNodes[2].InnerText.ToString()
                    }) ;
                    FlgCount++;
                }
                //验证是否一致数据
                DbContextFace<NewestMovie>  Server = new DbContextFace<NewestMovie>();
                var mapList = Server.All();
                if (mapList == null || mapList.Count == 0)
                {
                    Server.AddRange(InsertData);
                    Message = "数据库数据为空 -- 插入成功 /n";
                }
                else
                {
                    foreach (var item in mapList)
                    {
                        //清空数据
                        Server.Delete(item.Id);
                        Message += "数据清楚成功！/n";
                    }
                    //插入数据
                    Server.AddRange(InsertData);
                    Message += "数据添加成功";
                }
                //日志写入
                LogStreamWrite.WriteLineLog(Message);
            });
        }

        //private string JudgeMovieDefinition(string Definition)
        //{
        //    if (Definition == ConstantsKey.) { }
        //}
    }
}
