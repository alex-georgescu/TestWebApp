using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TestWebApp.Utils;


namespace TestWebApp.HttpHelper
{
    public class HttpGetHelper
    {
        public static async Task<string> GetAsync(string url,
                                    Dictionary<string, string> headers = null,
                                    object state = null,
                                    string contentType = null)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = Constants.GET;
            
            if (headers != null && headers.Any())
            {
                httpWebRequest.Headers = new WebHeaderCollection();
                foreach (KeyValuePair<string, string> header in headers)
                {
                    httpWebRequest.Headers[header.Key] = header.Value;
                }
            }

            WebResponse webResponse = await httpWebRequest.GetResponseAsync();
            if (webResponse != null)
            {
                Stream responseStream = webResponse.GetResponseStream();
                if (responseStream != null)
                {
                    StreamReader sr = new StreamReader(responseStream);
                    string resultAsString = sr.ReadToEnd();

                    return resultAsString;
                }
            }

            return null;
        }

    }
}