using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface IHttpRequestDomainService
    {
        Task<string> HttpRequest(string Url);
    }
}
