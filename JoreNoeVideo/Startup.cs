
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
            //�������
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddCors(options => options.AddPolicy("AllowCors", builder => builder.AllowAnyOrigin().AllowAnyMethod()));
            //���Swagger
            this.AddSwagger(services);
            this.EnableQueztr();
        }
        /// <summary>
        /// ��ʱ����
        /// </summary>
        public void EnableQueztr()
        {
            var trigger3 = TriggerBuilder.Create()
                       .WithSimpleSchedule(x => x.WithIntervalInSeconds(2).WithRepeatCount(1).RepeatForever())//���2�� һֱִ��
                       .UsingJobData("Url", "https://www.ekmov.com/")  //ͨ����Trigger����Ӳ���ֵ
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
        /// ���� autofac 
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //ҵ���߼������ڳ��������ռ�
            Assembly service = Assembly.Load("JoreNoeVideo.DomainServices");//�ӿڲ����ڳ��������ռ�
            Assembly repository = Assembly.Load("JoreNoeVideo.Store");//�Զ�ע��            builder.RegisterAssemblyTypes(service, repository)
            builder.RegisterAssemblyTypes(service, repository)
            .Where(t => t.Name.EndsWith("DomainService"))
                .AsImplementedInterfaces();//ע��ִ�������IRepository�ӿڵ�Repository��ӳ��
            builder.RegisterGeneric(typeof(DbContextFace<>))//InstancePerDependency��Ĭ��ģʽ��ÿ�ε��ã���������ʵ��������ÿ�����󶼴���һ���µĶ���
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
