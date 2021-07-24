using AutoMapper;
using AutoMapper.Configuration;
using JoreNoeVideo.Abstractions.Values;
using JoreNoeVideo.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoreNoeVideo
{
    public partial class Startup
    {
        protected void AddAutoMapper(IServiceCollection services)
        {
            services.TryAddSingleton<MapperConfigurationExpression>();
            services.TryAddSingleton(serviceProvider =>
            {
                var mapperConfigurationExpression = serviceProvider.GetRequiredService<MapperConfigurationExpression>();
                var instance = new MapperConfiguration(mapperConfigurationExpression);

                instance.AssertConfigurationIsValid();

                return instance;
            });
            services.TryAddSingleton(serviceProvider =>
            {
                var mapperConfiguration = serviceProvider.GetRequiredService<MapperConfiguration>();

                return mapperConfiguration.CreateMapper();
            });
        }
        public void UseAutoMapper(IApplicationBuilder applicationBuilder)
        {
            var config = applicationBuilder.ApplicationServices.GetRequiredService<MapperConfigurationExpression>();
            config.CreateMap<MovieComment, MovieCommentValue>(MemberList.None);
            //config.CreateMap<User, UserInfo>().ForMember(d => d.names, option => option.MapFrom(d => d.name)).ReverseMap();
        }
    }
}
