using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace JoreNoeVideo.DomainServices.Tools
{
    public static class LogStream
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="LogContext"></param>
        public static void WriteLine(string LogContext)
        {
            string Path = Assembly.GetEntryAssembly().Location;
            using (StreamWriter Sw = new StreamWriter(Path,true,Encoding.UTF8))
            {
                Sw.WriteLine(LogContext + "写入时间："+DateTime.Now);
            }
        }
    }
}
