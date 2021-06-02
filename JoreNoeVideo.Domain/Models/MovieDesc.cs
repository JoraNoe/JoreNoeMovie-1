using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JoreNoeVideo.Domain.Models
{
    /// <summary>
    /// 最新
    /// </summary>
    public class MovieDesc : BaseModel
    {
        /// <summary>
        /// 影片类型
        /// </summary>
        public List<MovieCategory> Category { get; set; }
        /// <summary>
        /// 导演
        /// </summary>
        public string Director { get; set; }
        /// <summary>
        /// 主演
        /// </summary>
        public string MainDirector { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 影片集数
        /// </summary>
        public virtual List<MovieCollections> MovieCollections { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 影片ID
        /// </summary>
        public string MovieId { get; set; }
    }
}
