using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace JoreNoeVideo.DomainServices
{
    /// <summary>
    /// 请求
    /// </summary>
    public class HttpRequestDomianService : IHttpRequestDomainService
    {
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public string HttpRequest(string Url)
        {
            WebRequest Request = null;
            HttpWebResponse Response = null;
            Stream _Stream = null;
            StreamReader Reader = null;
            string HTML = "";
            try
            {
                Request = WebRequest.Create(Url);
                Request.Method = "get";
                Request.Proxy = null;
                Request.ContentType = "application/json";
                Request.Timeout = 80000;
                Response = (HttpWebResponse)Request.GetResponse();
                _Stream = Response.GetResponseStream();
                Reader = new StreamReader(_Stream, Encoding.UTF8);
                HTML = Reader.ReadToEnd();
                //Request.Abort();
                Response.Close();
                _Stream.Close();
                Reader.Close();
                return HTML;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Request != null)
                    Request.Abort();
                if (Response != null)
                    Response.Close();
                if (_Stream != null)
                    _Stream.Close();
                if (Reader != null)
                    Reader.Close();
            }
        }
    }
}
