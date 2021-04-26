﻿// <auto-generated />
using System;
using JoreNoeVideo.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JoreNoeVideo.Store.Migrations
{
    [DbContext(typeof(JoreNoeVideoDbContext))]
    partial class JoreNoeVideoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JoreNoeVideo.Domain.MainlandOpera", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MovieDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MainlandOperas");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.AmericanOpera", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MovieDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AmericanOperas");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.AnimationOpera", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MovieDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimationOperas");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.CarouselMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarouseMaps");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.FilmOpera", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MovieDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FilmOperas");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.HongKongOpera", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MovieDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HongKongOperas");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.KoreanDramaOpera", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MovieDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KoreanDramaOperas");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MovieDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MovieDesctionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MovieImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieDesctionId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.MovieCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MovieDescId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MovieDescId");

                    b.ToTable("MovieCategorys");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.MovieCollections", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ColletionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MovieDescId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MovieDescId");

                    b.ToTable("MovieCollections");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.MovieDesc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Describe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MainDirector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MovieDescs");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.NewestMovie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MovieDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NewestMovies");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.Notice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("NoticeContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoticeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.SystemIcon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("SystemIcons");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Citry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserHeaderImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.UserBaseInFo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("HeaderImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserBaseInFos");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.MovieComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentContext")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("MovieComments");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.Movie", b =>
                {
                    b.HasOne("JoreNoeVideo.Domain.Models.MovieDesc", "MovieDesction")
                        .WithMany()
                        .HasForeignKey("MovieDesctionId");

                    b.Navigation("MovieDesction");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.MovieCategory", b =>
                {
                    b.HasOne("JoreNoeVideo.Domain.Models.MovieDesc", null)
                        .WithMany("Category")
                        .HasForeignKey("MovieDescId");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.MovieCollections", b =>
                {
                    b.HasOne("JoreNoeVideo.Domain.Models.MovieDesc", null)
                        .WithMany("MovieCollections")
                        .HasForeignKey("MovieDescId");
                });

            modelBuilder.Entity("JoreNoeVideo.Domain.Models.MovieDesc", b =>
                {
                    b.Navigation("Category");

                    b.Navigation("MovieCollections");
                });
#pragma warning restore 612, 618
        }
    }
}
