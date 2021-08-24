using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Domain;

namespace JoreNoeVideo.Store
{
    public class JoreNoeVideoDbContext : DbContext
    {
        public JoreNoeVideoDbContext()
        {
            //如果要访问的数据库存在，则不做操作，如果不存在，会自动创建所有数据表和模式
            //Database.EnsureCreated();

        }
        /// <summary>
        /// 配置
        /// </summary>
        private IConfiguration Configuration { set; get; }
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// 用户基本信息
        /// </summary>
        public DbSet<UserBaseInFo> UserBaseInFos { get; set; }
        /// <summary>
        /// 轮播图
        /// </summary>
        public DbSet<CarouselMap> CarouseMaps { get; set; }
        /// <summary>
        /// 最新影视
        /// </summary>
        public DbSet<NewestMovie> NewestMovies { get; set; }
        /// <summary>
        /// 影视分裂
        /// </summary>
        public DbSet<MovieCategory> MovieCategorys { get; set; }
        /// <summary>
        /// 某个影片描述
        /// </summary>
        public DbSet<MovieDesc> MovieDescs { get; set; }
        /// <summary>
        /// 某个影视集数
        /// </summary>
        public DbSet<MovieCollections> MovieCollections { get; set; }
        /// <summary>
        /// 影视评论
        /// </summary>
        public DbSet<MovieComment> MovieComments { get; set; }
        /// <summary>
        /// 影视
        /// </summary>
        public DbSet<Movie> Movies { get; set; }
        /// <summary>
        /// 美剧
        /// </summary>
        public DbSet<AmericanOpera> AmericanOperas { get; set; }
        /// <summary>
        /// 动漫
        /// </summary>
        public DbSet<AnimationOpera> AnimationOperas { get; set; }
        /// <summary>
        /// 电影
        /// </summary>
        public DbSet<FilmOpera> FilmOperas { get; set; }
        /// <summary>
        /// 港剧
        /// </summary>
        public DbSet<HongKongOpera> HongKongOperas { get; set; }
        /// <summary>
        /// 韩剧
        /// </summary>
        public DbSet<KoreanDramaOpera> KoreanDramaOperas { get; set; }
        /// <summary>
        /// 大陆剧
        /// </summary>
        public DbSet<MainlandOpera> MainlandOperas { get; set; }
        /// <summary>
        /// 公告
        /// </summary>
        public DbSet<Notice> Notices { get; set; }
        /// <summary>
        /// 系统标题
        /// </summary>
        public DbSet<SystemIcon> SystemIcons { get; set; }

        /// <summary>
        /// 用户点赞影片
        /// </summary>
        public DbSet<UserLikeMovie> UserLikeMovies { get; set; }

        /// <summary>
        /// 用户建议
        /// </summary>
        public DbSet<Proposal> Proposals { get; set; }

        /// <summary>
        /// 用户观看历史记录
        /// </summary>
        public DbSet<UserWatchHistory> UserWatchHistories { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //上下文重写此方法，以配置要使用的数据库。对上下文的每个实例调用此方法创建
            //IConfiguration congifuration = new ConfigurationBuilder();

            //optionsBuilder.UseSqlServer(this.Configuration.GetConnectionString("NotificationDBContext"));

            if (!string.IsNullOrEmpty(this.Configuration.GetConnectionString("connectionString")))
                optionsBuilder.UseSqlServer(this.Configuration.GetConnectionString("connectionString"));
            else
                optionsBuilder.UseSqlServer("Server=192.168.2.104;Database=JoreNoeDbContext;Uid=sa;Password=sa");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
