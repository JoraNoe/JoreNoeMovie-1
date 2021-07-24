using JoreNoeVideo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Abstractions.Values
{
    public class MovieCommentValue:BaseModel
    {
        public string UserHeaderImg { get; set; }

        public string UserName { get; set; }

        public string CommentContext { get; set; }

        public Guid UserId { get; set; }

        public Guid MovieId { get; set; }
    }
}
