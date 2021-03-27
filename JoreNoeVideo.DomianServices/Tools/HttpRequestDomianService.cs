using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace JoreNoeVideo.DomainServices.Tools
{
    public class HttpRequestDomianService:IHttpRequestDomainService
    {
        public string HttpRequest(string Url)
        {
            string HTML = "";
            WebRequest Request = WebRequest.Create(Url);
            Request.Method = "get";
            Request.Proxy = null;
            Request.ContentType = "application/json";
            Request.Timeout = 50000;
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            Stream _Stream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(_Stream, Encoding.UTF8);
            HTML = Reader.ReadToEnd();
            Request.Abort();
            Response.Close();
            _Stream.Close();
            Reader.Close();
            return HTML;
        }
    }
}
