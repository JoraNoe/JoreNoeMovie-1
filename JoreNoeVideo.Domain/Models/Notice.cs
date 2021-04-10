using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 公告
    /// </summary>
    public class Notice:BaseModel
    {
        /// <summary>
        /// 公告标题
        /// </summary>
        public string NoticeTitle { get; set; }
        /// <summary>
        /// 公告内容
        /// </summary>
        public string NoticeContent { get; set; }
    }
}
