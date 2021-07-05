using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.Cache
{
    public interface IRedisCache
    {
        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        IDatabase GetDatabase();
    }
}
