﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoreNoeVideo.CommonInterFaces
{
    /// <summary>
    /// Api返回信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class APIReturnInFo<T>
    {
        public static APIReturnInFo<T> Success(T Data)
        {
            return new APIReturnInFo<T> { Data = Data  };
        }

        public static APIReturnInFo<T> Error(string Message)
        {
            return new APIReturnInFo<T> { Data = default(T), Message = Message, Status = false };

        }

        public bool State { get; set; } = true;
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; } = true;
    }
}
