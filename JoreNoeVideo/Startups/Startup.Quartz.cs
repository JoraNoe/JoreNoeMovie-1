using JoreNoeVideo.DomainServices.TimerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoreNoeVideo
{
    public partial class Startup
    {
        protected void EnableQuartz()
        {
            //爬取 轮播图 图片
            {
                IScheduler scheduler;
                ISchedulerFactory factory = new StdSchedulerFactory();
                scheduler = factory.GetScheduler().Result;
                scheduler.Start();

                //创建触发器(也叫时间策略)
                var trigger = TriggerBuilder.Create()
                                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(3, 30))
                                //.WithSimpleSchedule(x => x.DailyAtHourAndMinute(10).RepeatForever())//每10秒执行一次
                                .Build();
                //创建作业实例
                //Jobs即我们需要执行的作业
                var jobDetail = JobBuilder.Create<TimerAddCarouse>()
                                .UsingJobData("Url", "https://www.ekmov.com/")
                                .WithIdentity("Myjob", "group")//我们给这个作业取了个“Myjob”的名字，并取了个组名为“group”
                                .Build();
                //将触发器和作业任务绑定到调度器中
                scheduler.ScheduleJob(jobDetail, trigger);
            }


            //爬取 最新视频
            {
                IScheduler scheduler;
                ISchedulerFactory factory = new StdSchedulerFactory();
                scheduler = factory.GetScheduler().Result;
                scheduler.Start();

                //创建触发器(也叫时间策略)
                var trigger = TriggerBuilder.Create()
                                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(2, 30))
                                //.WithSimpleSchedule(x => x.DailyAtHourAndMinute(10).RepeatForever())//每10秒执行一次
                                .Build();
                //创建作业实例
                //Jobs即我们需要执行的作业
                var jobDetail = JobBuilder.Create<TimerAddNewest>()
                                .UsingJobData("Url", "https://www.ekmov.com/")
                                .WithIdentity("Myjob", "group")//我们给这个作业取了个“Myjob”的名字，并取了个组名为“group”
                                .Build();
                //将触发器和作业任务绑定到调度器中
                scheduler.ScheduleJob(jobDetail, trigger);
            }


        }
    }
}
