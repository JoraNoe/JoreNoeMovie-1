using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain
{
    /// <summary>
    /// 评论
    /// </summary>
    public class MovieComment:BaseModel
    {
        public string CommentContext { get; set; }

        public Guid UserId { get; set; }

        public Guid MovieId { get; set; }
    }
}
