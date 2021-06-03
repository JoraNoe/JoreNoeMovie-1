
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
using Microsoft.Extensions.FileProviders;
using System.IO;
using JoreNoeVideo.API.Filter;

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
            //ע��ȫ�ֹ�����
            services.AddControllersWithViews(options=> {
                options.Filters.Add<UserAuthentication>();
            });
            //���Swagger
            this.AddSwagger(services);
            //��ʱ
            this.EnableQuartz();
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
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
              Path.Combine(Directory.GetCurrentDirectory(), "SystemIcon")),
                RequestPath = "/SystemIcon",
                EnableDirectoryBrowsing = true
            });

            app.UseCors();

            var builder = new ConfigurationBuilder()
                   .SetBasePath(env.ContentRootPath)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables();

            this.UseSwagger(app);

        }
    }
}
