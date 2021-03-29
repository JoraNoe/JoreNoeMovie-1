using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain
{
    /// <summary>
    /// 大陆剧
    /// </summary>
    public class MainlandOpera
    {
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
        /// 底部标题
        /// </summary>
        public string MovieTitle { get; set; }
    }
}
