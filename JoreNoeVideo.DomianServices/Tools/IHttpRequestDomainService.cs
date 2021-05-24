using System;
using System.Collections.Generic;
using System.Text;

namespace JoreNoeVideo.DomainServices
{
    public interface IHttpRequestDomainService
    {
        string HttpRequest(string Url);
    }
}
