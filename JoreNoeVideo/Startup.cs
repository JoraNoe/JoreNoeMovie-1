
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

            //services.AddTransient<IUserDomainService, UserDomainService>();
            //services.AddTransient<IDbContextFace<>, DbContextFace<>>();
            //services.AddControllers().AddControllersAsServices();

        }
      
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

            //var config = new ConfigurationBuilder();
            //config.AddJsonFile("Configs/Autofac.json");
            //builder.RegisterModule(new ConfigurationModule(config.Build()));
            // 直接用Autofac注册我们自定义的 
            //builder.RegisterModule(new DomainServiceModule(builder));

        }

        //autofac 新增
        public ILifetimeScope AutofacContainer { get; private set; }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            //autofac 新增 
            //this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();


        }
    }
}
