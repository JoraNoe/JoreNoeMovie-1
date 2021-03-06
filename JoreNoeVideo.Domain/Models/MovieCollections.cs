using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 影片集数
    /// </summary>
    public class MovieCollections:BaseModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string ColletionName { get; set; }
        /// <summary>
        /// 播放跳转链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 影片Id
        /// </summary>
        public string MovieId { get; set; }

        /// <summary>
        /// 播放地址
        /// </summary>
        public string PlayerLink { get; set; }
    }
}
