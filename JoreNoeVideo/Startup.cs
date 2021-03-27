
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
            //�������
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddCors(options => options.AddPolicy("AllowCors", builder => builder.AllowAnyOrigin().AllowAnyMethod()));
            //���Swagger
            this.AddSwagger(services);

            //services.AddTransient<IUserDomainService, UserDomainService>();
            //services.AddTransient<IDbContextFace<>, DbContextFace<>>();
            //services.AddControllers().AddControllersAsServices();

        }
      
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

            //var config = new ConfigurationBuilder();
            //config.AddJsonFile("Configs/Autofac.json");
            //builder.RegisterModule(new ConfigurationModule(config.Build()));
            // ֱ����Autofacע�������Զ���� 
            //builder.RegisterModule(new DomainServiceModule(builder));

        }

        //autofac ����
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

            //autofac ���� 
            //this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();


        }
    }
}
