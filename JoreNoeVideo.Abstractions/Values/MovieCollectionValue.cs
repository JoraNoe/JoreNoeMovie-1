using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Abstractions.Values
{
    public class MovieCollectionValue
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
        /// <summary>
        /// 播放类型
        /// </summary>
        public int ModelType { get; set; }

        public Guid Id { get; set; }

        public int Index { get; set; }
    }
}
