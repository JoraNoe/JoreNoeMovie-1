using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 轮播图
    /// </summary>
    public class CarouselMap:BaseModel
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 顺序
        /// </summary>
        public int Sort { get; set; }

    }
}
