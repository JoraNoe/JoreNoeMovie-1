using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Domain;

namespace JoreNoeVide.Store
{
    public class JoreNoeVideoDbContext:DbContext
    {
        public JoreNoeVideoDbContext()
        {
            //如果要访问的数据库存在，则不做操作，如果不存在，会自动创建所有数据表和模式
            //Database.EnsureCreated();
           
        }
        /// <summary>
        /// 
        /// </summary>
        private IConfiguration Configuration;

        public DbSet<User> Users { get; set; }

        public DbSet<UserBaseInFo> UserBaseInFos { get; set; }

        public DbSet<CarouselMap> CarouseMaps { get; set; }

        public DbSet<NewestMovie> NewestMovies { get; set; }

        public DbSet<MovieCategory> MovieCategorys { get; set; }

        public DbSet<MovieDesc> MovieDescs { get; set; }

        public DbSet<MovieCollections> MovieCollections { get; set; }

        public DbSet<MovieComment> MovieComments { get; set; }

        public DbSet<Movie> Movies { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //上下文重写此方法，以配置要使用的数据库。对上下文的每个实例调用此方法创建
            //IConfiguration congifuration = new ConfigurationBuilder();

            //optionsBuilder.UseSqlServer(this.Configuration.GetConnectionString("NotificationDBContext"));
            optionsBuilder.UseSqlServer("Server=192.168.2.100;Database=JoreNoeDbContext;Uid=sa;Password=sa");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
