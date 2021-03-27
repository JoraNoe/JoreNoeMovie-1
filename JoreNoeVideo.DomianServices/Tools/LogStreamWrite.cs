using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace JoreNoeVideo.DomainServices.Tools
{
    public static class LogStreamWrite
    {
        public static void WriteLineLog(string LogContext)
        {
            using (StreamWriter Ws = new StreamWriter(Assembly.GetEntryAssembly().Location,true,Encoding.UTF8))
            {
                Ws.WriteLine(LogContext + "--写入时间："+DateTime.Now);
            }
        }
    }
}
