using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    public class UserBaseInFo:BaseModel
    {
        public string HeaderImgUrl { get; set; }

        public int Sex  { get; set; }
    }
}
