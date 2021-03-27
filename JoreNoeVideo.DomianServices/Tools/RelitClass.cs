using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.DomainServices.Tools
{
    public static class RelitClass
    {
        public static IHttpRequestDomainService HttpRequestDomain { get; set; } = new HttpRequestDomianService();
        public static IDbContextFace<CarouselMap> Server { get; set; } = new DbContextFace<CarouselMap>();
    }
}
