using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.DomainServices.Tools
{
    /// <summary>
    /// 临时文件
    /// </summary>
    public static class RelitClass
    {
        public static IHttpRequestDomainService HttpRequestDomain { get; set; } = new HttpRequestDomianService();
    }
}
