using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 用户建议
    /// </summary>
    public class Proposal:BaseModel
    {
        /// <summary>
        /// 建议消息
        /// </summary>
        public string ProposalContext { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }
    }
}
