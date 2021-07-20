using JoreNoeVideo.DomainServices.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    /// <summary>
    /// 请求
    /// </summary>
    public class HttpRequestDomainService : IHttpRequestDomainService
    {
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public async Task<string> HttpRequest(string Url)
        {
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "GET";
            //string respContent = "";
            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    if (httpResponse.StatusCode == HttpStatusCode.OK)
            //    {
            //        respContent = await streamReader.ReadToEndAsync();
            //    }
            //}
            //return respContent;


            //string THML = "";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //using (StreamReader readStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            //{
            //    THML = await readStream.ReadToEndAsync();
            //}


            if (string.IsNullOrEmpty(Url))
                return string.Empty;

            string HttpWebRequestHTMl = "";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = WebRequest.Create(Url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.Method = "GEt";
                request.Timeout = 12000;
                //request.ReadWriteTimeout = Const.HttpClientReadWriteTimeout;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                request.ServicePoint.ConnectionLimit = 2000;
                request.AllowWriteStreamBuffering = false;
                request.Proxy = null;

                using (response = (HttpWebResponse)request.GetResponse())
                {
                    string encoding = response.ContentEncoding;
                    using (var stream = response.GetResponseStream())
                    {
                        if (string.IsNullOrEmpty(encoding) || encoding.Length < 1)
                        {
                            encoding = "UTF-8"; //默认编码
                        }

                        if (stream != null)
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(encoding)))
                            {
                                HttpWebRequestHTMl = await reader.ReadToEndAsync().ConfigureAwait(false);

                            }
                        }
                        else
                        {
                            throw new Exception("响应流为null!");
                        }
                    }
                }
            }
            catch (Exception err)
            {
                LogStreamWrite.WriteLineLog("Http抛出异常+" + err.Message);
            }
            finally
            {
                response?.Close();
                request?.Abort();
            }

            return HttpWebRequestHTMl;

            //WebRequest Request = null;
            //HttpWebResponse Response = null;
            //Stream _Stream = null;
            //StreamReader Reader = null;
            //string HTML = "";
            //try
            //{
            //    Request = WebRequest.Create(Url);
            //    Request.Method = "get";
            //    Request.Proxy = null;
            //    Request.ContentType = "application/json";
            //    Request.Timeout = 80000;
            //    Response = (HttpWebResponse)Request.GetResponse();
            //    _Stream = Response.GetResponseStream();
            //    Reader = new StreamReader(_Stream, Encoding.UTF8);
            //    HTML = await Reader.ReadToEndAsync();
            //    //Request.Abort();
            //    //Response.Close();
            //    //_Stream.Close();
            //    //Reader.Close();

            //}
            //catch (Exception ex)
            //{
            //    LogStreamWrite.WriteLineLog("HttpRequest请求错误：" + ex.Message);
            //}
            //finally
            //{
            //    if (Request != null)
            //        Request.Abort();
            //    if (Response != null)
            //        Response.Close();
            //    if (_Stream != null)
            //        _Stream.Close();
            //    if (Reader != null)
            //        Reader.Close();
            //}
        }
    }
}
