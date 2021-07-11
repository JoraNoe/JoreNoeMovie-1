using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 影片分类
    /// </summary>
    public class MovieCategory:BaseModel
    {
        /// <summary>
        /// 影视分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderBy { get; set; }

        /// <summary>
        /// 分类地址
        /// </summary>
        public string CategoryUrl { get; set; }
    }
}
