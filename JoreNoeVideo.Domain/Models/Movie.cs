using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    public class Movie : BaseModel
    {
        /// <summary>
        /// 首页视频
        /// </summary>
        public const string MOVIE_CATEGORY_INDEX = "Index";

        /// <summary>
        /// 影片名称
        /// </summary>
        public string MovieName { get; set; }
        /// <summary>
        /// 影片图片地址
        /// </summary>
        public string MovieImgUrl { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string MovieLink { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string MovieDesc { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public virtual MovieDesc MovieDesction { get; set; }

        /// <summary>
        /// 影视标题 可空
        /// </summary>
        public string MovieTitle { get; set; }

        /// <summary>
        /// 喜欢数量 
        /// </summary>
        public int Likes { get; set; }

        /// <summary>
        /// 不喜欢数量
        /// </summary>
        public int DisLikes { get; set; }

        /// <summary>
        /// 电影类型 
        /// </summary>
        public string MovieCategory { get; set; }
    }
}
