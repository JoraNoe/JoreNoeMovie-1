using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User:BaseModel
    {
        /// <summary>
        /// 使用Id  对应 Signature 签名
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市 
        /// </summary>
        public string Citry { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 用户头像 长连接
        /// </summary>
        public string UserHeaderImg { get; set; }
    }
}
