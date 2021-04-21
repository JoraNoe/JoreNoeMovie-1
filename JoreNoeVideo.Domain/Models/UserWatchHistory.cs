using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 用户观看历史
    /// </summary>
    public class UserWatchHistory
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
        /// 影片链接
        /// </summary>
        public string MovieLink { get; set; }
    }
}
