using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 系统图标
    /// </summary>
    public class SystemIcon:BaseModel
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string IconUrl { get; set; }
    }
}
