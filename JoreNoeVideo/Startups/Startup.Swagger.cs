using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace JoreNoeVideo
{
    /// <summary>
    /// swagger
    /// </summary>
    public partial class Startup
    {
        protected void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "影视appApi", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "JoreNoeVideo.API.xml"), true);
            });
        }

        protected void UseSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(option => { option.SwaggerEndpoint("/swagger/v1/swagger.json", "影视AppApi"); });
        }

    }
}
