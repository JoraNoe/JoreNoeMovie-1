using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JoreNoeVideo.DomainServices.Tools
{
    /// <summary>
    /// 临时文件
    /// </summary>
    public static class RelitClass
    {
        public static IHttpRequestDomainService HttpRequestDomain { get; set; } = new HttpRequestDomainService();

        public static string removeNotNumber(string key,out bool IsJudge)
        {
            IsJudge = false;
            if (string.IsNullOrEmpty(Regex.Replace(key, @"[^\d]", "")))
                return key;

            IsJudge = true;
            return Regex.Replace(key, @"[^\d]*", "");
        }
        public static string removeNotNumber(string key)
        {
            return Regex.Replace(key, @"[^\d]*", "");
        }
    }

}
