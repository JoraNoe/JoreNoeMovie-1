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
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 基本信息
        /// </summary>
        [ForeignKey("UserId")]
        public UserBaseInFo UserBaseInFo { get; set; }

        public Guid UserId { get; set; }
    }
}
