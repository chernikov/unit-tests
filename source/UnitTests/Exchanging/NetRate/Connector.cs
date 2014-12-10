using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetRate
{
    public class Connector
    {
      
        public string GetResource(string uri, RequestMethodType requestMethod, List<KeyValuePair<string, string>> parameters, int timeout = 20000)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uri))
                {
                    throw new ArgumentNullException("Empty Uri");
                }
                var webResponse = GetHttpRequest(uri, requestMethod, parameters, timeout);

                var responceStream = webResponse.GetResponseStream();
                var enc = System.Text.Encoding.GetEncoding(1251);
                var loResponseStream = new
                    StreamReader(webResponse.GetResponseStream(), enc);

                return loResponseStream.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        /*
        public string GetResource(string uri, RequestMethodType requestMethod, string parameters, int timeout = 10000)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uri))
                {
                    throw new ArgumentNullException("Invalid address specified");
                }
                var webResponse = GetHttpRequest(uri, requestMethod, parameters, timeout);

                var enc = Encoding.GetEncoding(1251);
                var loResponseStream = new
                        StreamReader(webResponse.GetResponseStream(), enc);

                return loResponseStream.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw;
            }
        }*/

        private WebResponse GetHttpRequest(string uri, RequestMethodType requestMethod, List<KeyValuePair<string, string>> parameters, int timeout, string referer = null)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("Not specified Uri");
            }

            Uri realUri = null;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out realUri))
            {
                throw new ArgumentException("Invalid address specified");
            }

            HttpWebRequest webRequest = null;
            if (requestMethod == RequestMethodType.Get)
            {
                if (parameters != null && parameters.Count > 0)
                {
                    webRequest = (HttpWebRequest)WebRequest.Create(
                        string.Format("{0}?{1}", uri, ParamsString(parameters)));
                }
                else
                {
                    webRequest = (HttpWebRequest)WebRequest.Create(uri);
                }
                webRequest.Method = "GET";
            }
            else if (requestMethod == RequestMethodType.Post)
            {
                webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.Method = "POST";
            }
            webRequest.ContentType = "application/x-www-form-urlencoded";
            if (!string.IsNullOrWhiteSpace(referer))
            {
                webRequest.Referer = referer;
            }
            webRequest.KeepAlive = false;
            webRequest.PreAuthenticate = false;
            webRequest.Timeout = timeout;
            if (requestMethod == RequestMethodType.Post)
            {
                CreateParams(ParamsString(parameters), webRequest);
            }
            return webRequest.GetResponse();
        }

        private WebResponse GetHttpRequest(string uri, RequestMethodType requestMethod, string parameters, int timeout)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("Not specified Uri");
            }

            Uri realUri = null;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out realUri))
            {
                throw new ArgumentException("Invalid address specified");
            }

            HttpWebRequest webRequest = null;
            if (requestMethod == RequestMethodType.Get)
            {
                if (parameters != null)
                {
                    webRequest = (HttpWebRequest)WebRequest.Create(
                        string.Format("{0}?{1}", uri, parameters));
                }
                else
                {
                    webRequest = (HttpWebRequest)WebRequest.Create(uri);
                }
                webRequest.Method = "GET";
            }
            else if (requestMethod == RequestMethodType.Post)
            {
                webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.Method = "POST";
            }
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.KeepAlive = false;
            webRequest.PreAuthenticate = false;
            webRequest.Timeout = timeout;
            if (requestMethod == RequestMethodType.Post)
            {
                CreateParams(parameters, webRequest);
            }
            return webRequest.GetResponse();
        }

        private void CreateParams(string parameterString, HttpWebRequest webRequest)
        {
            var enc = System.Text.Encoding.GetEncoding(1251);
            byte[] byteArray = enc.GetBytes(parameterString);
            webRequest.ContentLength = byteArray.Length;
            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

        private string ParamsString(List<KeyValuePair<string, string>> parameters)
        {
            StringBuilder sb = new StringBuilder(1024);

            foreach (var keyValuePair in parameters)
            {
                sb.AppendFormat("{0}={1}&", keyValuePair.Key, keyValuePair.Value);
            }
            //remove last "&"
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
