using HtmlAgilityPack;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices.Tools
{
    public class TimerAddCarouse: IJob
    {
        public TimerAddCarouse(IDbContextFace<CarouselMap> Server, IHttpRequestDomainService httpRequestDomain)
        {
            this.HttpRequestDomain = httpRequestDomain;
            this.Server = Server;
        }

        private readonly IHttpRequestDomainService HttpRequestDomain;
        private readonly IDbContextFace<CarouselMap> Server;
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                var jobData = context.JobDetail.JobDataMap;//获取Job中的参数
                string Url = jobData.GetString("Url");
                string Message = "";
                var DocumentHtml = this.HttpRequestDomain.HttpRequest(Url);
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(DocumentHtml);
                var DataNode = html.DocumentNode.SelectNodes("//a[@class='box-model-cont fn-clear']");
                var InsertData = new List<CarouselMap>();
                var FlgCount = 0;
                foreach (var item in DataNode)
                {
                    //只取五条数据
                    if (FlgCount == 5)
                    {
                        break;
                    }
                    InsertData.Add(new CarouselMap
                    {
                        ImgUrl = item.ChildNodes[0].ChildNodes[0].Attributes["src"].Value.ToString(),
                        Link = Url + item.Attributes["href"].Value.ToString(),
                        Sort = FlgCount + 1
                    });
                    FlgCount++;
                }
                //验证是否一致数据
                var mapList = this.Server.All();
                if (mapList == null && mapList.Count == 0)
                {
                    this.Server.AddRange(InsertData);
                    Message = "数据库数据为空 -- 插入成功 /n";
                }
                else
                {
                    foreach (var item in mapList)
                    {
                        //清空数据
                        this.Server.Delete(item.Id);
                        Message += "数据清楚成功！/n";
                    }
                    //插入数据
                    this.Server.AddRange(InsertData);
                    Message += "数据添加成功";
                }

                return Message;
            });
        }
    }
}
