using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 用户进入历史记录
    /// </summary>
    public class UserOptionHistory:BaseModel
    {
        /// <summary>
        /// 用户Ip地址
        /// </summary>
        public string  UserIpAddress { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string  Remark { get; set; }
    }
}
