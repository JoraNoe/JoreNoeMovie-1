using JoreNoeVideo.Abstractions.Values;
using JoreNoeVideo.Domain;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public class MovieCommentDomainService : IMovieCommentDomainService
    {
        private readonly IDbContextFace<MovieComment> server;

        private readonly IDbContextFace<User> UserService;

        private readonly IMapper Mapper;
        public MovieCommentDomainService(IDbContextFace<MovieComment> server, IDbContextFace<User> UserService, IMapper Mapper)
        {
            this.server = server;
            this.Mapper = Mapper;
            this.UserService = UserService;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieCommentValue> AddMovieComment(MovieComment model)
        {
            //新增数据
            var CreateInfo = await this.server.AddAsync(model).ConfigureAwait(false);

            //查询评论
            var MovieCommentInfos = await this.server.FindAsync(d => d.MovieId == CreateInfo.MovieId).ConfigureAwait(false);
            //筛选出评论中用户IDS
            var UserIds = MovieCommentInfos.Select(d => d.UserId);
            //查询用户信息
            var UserInfos = await this.UserService.FindAsync(d => UserIds.Contains(d.Id));

            var UserInfoDirection = UserInfos.ToDictionary(optionKey => optionKey.Id, optionValue => optionValue);

            var ConvertValue = Mapper.Map<MovieCommentValue>(CreateInfo);
            ConvertValue.UserHeaderImg = UserInfoDirection[CreateInfo.UserId].UserHeaderImg;
            ConvertValue.UserName = UserInfoDirection[CreateInfo.UserId].NickName;

            return ConvertValue;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IList<MovieComment>> AllMovieComment()
        {
            return await this.server.AllAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieComment> EditMovieComment(MovieComment model)
        {
            return await this.server.EditAsync(model).ConfigureAwait(false);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<MovieComment>> Pagin(int PageNum, int PageSize)
        {
            return await this.server.Page(PageNum, PageSize).ConfigureAwait(false);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<MovieComment> RemovedMovieComment(Guid Id)
        {
            return await this.server.DeleteRangeAsync(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<MovieComment> SingleMovieComment(Guid Id)
        {
            return await this.server.GetSingle(Id).ConfigureAwait(false);
        }

        /// <summary>
        /// 根据MoveId 查询 评论
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IList<MovieCommentValue>> FindMovieCommentByMovieId(Guid Id)
        {
            //查询评论
            var MovieCommentInfos = await this.server.FindAsync(d => d.MovieId == Id).ConfigureAwait(false);
            //筛选出评论中用户IDS
            var UserIds = MovieCommentInfos.Select(d => d.UserId);
            //查询用户信息
            var UserInfos = await this.UserService.FindAsync(d => UserIds.Contains(d.Id));

            var UserInfoDirection = UserInfos.ToDictionary(optionKey => optionKey.Id, optionValue => optionValue);

            IList<MovieCommentValue> ResultMovieComments = new List<MovieCommentValue>();

            foreach (var item in MovieCommentInfos)
            {
                var ConvertValue = Mapper.Map<MovieCommentValue>(item);
                ConvertValue.UserHeaderImg = UserInfoDirection[item.UserId].UserHeaderImg;
                ConvertValue.UserName = UserInfoDirection[item.UserId].NickName;
                ResultMovieComments.Add(ConvertValue);
            }

            return ResultMovieComments.OrderByDescending(d=>d.CreateTime).ToList();
        }
    }
}
