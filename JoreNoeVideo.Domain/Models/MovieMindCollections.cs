using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 影视中间表
    /// </summary>
    public class MovieMindCollections:BaseModel
    {
        public Guid MoviceId { get; set; }

        public Guid CollectionId { get; set; }
    }
}
