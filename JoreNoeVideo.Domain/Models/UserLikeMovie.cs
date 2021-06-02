using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    public class UserLikeMovie: BaseModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 影片ID
        /// </summary>
        public Guid MovieId { get; set; }
    }
}
