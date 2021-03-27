using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Domain
{
    public class BaseModel
    {
        public BaseModel()
        {
            this.Id = Guid.NewGuid();
            this.IsDelete = false;
            this.CreateTime = DateTime.Now;

        }
        public Guid Id { get; set; }

        public bool IsDelete { get; set; } = false;

        public DateTime CreateTime { get; set; }
    }
}
