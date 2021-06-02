using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace JoreNoeVideo.DomainServices.Tools
{
    /// <summary>
    /// 日志类 
    /// </summary>
    public static class LogStreamWrite
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="LogContext"></param>
        public static void WriteLineLog(string LogContext)
        {
            var CurrentSysPaht = Assembly.GetEntryAssembly().Location;
            var Path = CurrentSysPaht.Substring(0, CurrentSysPaht.LastIndexOf(@"\")) + "\\SystemLog.log";
            using (StreamWriter Ws = new StreamWriter(Path, true, Encoding.UTF8))
            {
                Ws.WriteLine(LogContext + "--写入时间：" + DateTime.Now);
            }
        }
    }
}
