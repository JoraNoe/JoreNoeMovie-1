
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
            this.EnableQueztr();
        }
        /// <summary>
        /// 定时任务
        /// </summary>
        public void EnableQueztr()
        {
            var trigger3 = TriggerBuilder.Create()
                       .WithSimpleSchedule(x => x.WithIntervalInSeconds(2).WithRepeatCount(1).RepeatForever())//间隔2秒 一直执行
                       .UsingJobData("Url", "https://www.ekmov.com/")  //通过在Trigger中添加参数值
                       .WithIdentity("TimerAddCarouse", "group1")
                       .Build();
            

            //IScheduler scheduler;
            //ISchedulerFactory factory = new StdSchedulerFactory();
            //scheduler = factory.GetScheduler().Result;
            //IJobDetail testJobDetail = JobBuilder.Create<TimerAddCarouse>().WithIdentity("TimerAddCarouse").Build();
            //ITrigger testJobTrigger = TriggerBuilder.Create().WithCronSchedule("0/5 * * * * ? *")
            //    .UsingJobData("Url", "https://www.ekmov.com/")
            //    .Build();
            //scheduler.ScheduleJob(testJobDetail, testJobTrigger);
            //scheduler.Start();
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

            this.UseSwagger(app);

        }
    }
}
