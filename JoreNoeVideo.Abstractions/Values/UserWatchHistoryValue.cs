using System;
using System.Collections.Generic;
using System.Text;
using JoreNoeVideo.Domain.Models;

namespace JoreNoeVideo.Abstractions.Models
{
    public class UserWatchHistoryValue
    {
        /// <summary>
        /// 电影名称
        /// </summary>
        public string MovieName { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 影片Id
        /// </summary>
        public Guid MovieId { get; set; }
        
        /// <summary>
        /// 电影
        /// </summary>
        public Movie Movie { get; set; }
        
        /// <summary>
        /// 影片链接
        /// </summary>
        public string MovieLink { get; set; }
    }
}
