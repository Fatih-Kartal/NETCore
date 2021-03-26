using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NETCore_Web_Api.Services
{
    public class RequestServices
    {
        public static Task<string> MakeAsyncRequest(string url/*, string contentType*/)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.ContentType = contentType;
            request.Method = WebRequestMethods.Http.Get;
            request.Timeout = 1000 * 3;
            request.Proxy = null;

            Task<WebResponse> task = Task.Factory.FromAsync(
                request.BeginGetResponse,
                asyncResult => request.EndGetResponse(asyncResult),
                (object)null);

            return task.ContinueWith(t => ReadStreamFromResponse(t.Result));
        }
        private static string ReadStreamFromResponse(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(responseStream))
            {
                string strContent = sr.ReadToEnd();
                return strContent;
            }
        }
    }
}
