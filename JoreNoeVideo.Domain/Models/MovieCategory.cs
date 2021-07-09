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
    }
}
