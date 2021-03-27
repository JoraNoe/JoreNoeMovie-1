﻿using HtmlAgilityPack;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices.Tools
{
    public class TimerAddCarouse: IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine(context.JobDetail.ToString());
            return Task.Run(() =>
            {
                var Server = RelitClass.Server;
                var HttpRequestDomain = RelitClass.HttpRequestDomain;
                var jobData = context.JobDetail.JobDataMap;//获取Job中的参数
                string Url = jobData.GetString("Url");
                string Message = "";
                var DocumentHtml = HttpRequestDomain.HttpRequest(Url);
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(DocumentHtml);
                var DataNode = html.DocumentNode.SelectSingleNode("//div[@class='box-model-cont fn-clear']");
                var InsertData = new List<CarouselMap>();
                var FlgCount = 0;
                foreach (var item in DataNode.ChildNodes)
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
                Server = new DbContextFace<CarouselMap>();
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
                using (StreamWriter sr = new StreamWriter("d:\\log.log",true,Encoding.UTF8))
                {
                    sr.WriteLine(Message + "时间：" + DateTime.Now);
                }
            });
        }
    }
}