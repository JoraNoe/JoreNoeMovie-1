
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Autofac;
using Autofac.Configuration;
using System;
using JoreNoeVideo.Store;
using System.Reflection;
using JoreNoeVideo.DomianServices;
using Autofac.Extensions.DependencyInjection;
using JoreNoeVideo.DomainServices;
using Quartz;
using Quartz.Impl;
using JoreNoeVideo.DomainServices.Tools;

namespace JoreNoeVideo
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //允许跨域
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddCors(options => options.AddPolicy("AllowCors", builder => builder.AllowAnyOrigin().AllowAnyMethod()));
            //添加Swagger
            this.AddSwagger(services);
            //定时
            //this.AddQuartz(services,typeof(TimerAddCarouse));

            this.EnableQueztr();
        }
        /// <summary>
        /// 定时任务
        /// </summary>
        public void EnableQueztr()
        {
            IScheduler scheduler;
            ISchedulerFactory factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler().Result;
            scheduler.Start();

            //创建触发器(也叫时间策略)
            var trigger = TriggerBuilder.Create()
                            .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(3,30))
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

        /// <summary>
        /// 配置 autofac 
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //业务逻辑层所在程序集命名空间
            Assembly service = Assembly.Load("JoreNoeVideo.DomainServices");//接口层所在程序集命名空间
            Assembly repository = Assembly.Load("JoreNoeVideo.Store");//自动注入            builder.RegisterAssemblyTypes(service, repository)
            builder.RegisterAssemblyTypes(service, repository)
            .Where(t => t.Name.EndsWith("DomainService"))
                .AsImplementedInterfaces();//注册仓储，所有IRepository接口到Repository的映射
            builder.RegisterGeneric(typeof(DbContextFace<>))//InstancePerDependency：默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象；
                .As(typeof(IDbContextFace<>)).InstancePerDependency();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors();
            // QuartzService.StartJob<TimerAddCarouse>();
            this.UseSwagger(app);

        }
    }
}
