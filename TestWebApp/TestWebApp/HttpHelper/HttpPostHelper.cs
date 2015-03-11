using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestWebApp.Utils;

namespace TestWebApp.HttpHelper
{
    public class HttpPostHelper
    {
        public static void PostAsync(string url,
                                      Dictionary<string, string> headers,
                                      Dictionary<string, string> postParameters,
                                      Action<HttpWebRequestCallbackState> responseCallback,
                                      object state = null,
                                      string contentType = "application/x-www-form-urlencoded")
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = Constants.POST;
            httpWebRequest.Headers = new WebHeaderCollection();
            foreach (KeyValuePair<string, string> header in headers)
            {
                httpWebRequest.Headers[header.Key] = header.Value;
            }

            httpWebRequest.BeginGetRequestStream(BeginGetRequestStreamCallback, new HttpWebRequestAsyncState()
            {
                RequestBytes = GetRequestBytes(postParameters),
                HttpWebRequest = httpWebRequest,
                ResponseCallback = responseCallback,
                State = state
            });
        }


        private static byte[] GetRequestBytes(Dictionary<string, string> postParameters)
        {
            if (postParameters == null || postParameters.Count == 0)
                return new byte[0];

            var sb = new StringBuilder();
            foreach (var key in postParameters.Keys)
            {
                sb.Append(key + "=" + postParameters[key] + "&");
            }

            sb.Length = sb.Length - 1;

            return Encoding.UTF8.GetBytes(sb.ToString());
        }


        private static void BeginGetRequestStreamCallback(IAsyncResult asyncResult)
        {
            Task.Run(() =>
            {
                Stream requestStream = null;
                HttpWebRequestAsyncState asyncState = null;
                try
                {
                    asyncState = (HttpWebRequestAsyncState)asyncResult.AsyncState;
                    requestStream = asyncState.HttpWebRequest.EndGetRequestStream(asyncResult);
                    requestStream.Write(asyncState.RequestBytes, 0, asyncState.RequestBytes.Length);
                    requestStream.Flush();
                    requestStream.Dispose();

                    asyncState.HttpWebRequest.BeginGetResponse(BeginGetResponseCallback, new HttpWebRequestAsyncState
                    {
                        HttpWebRequest = asyncState.HttpWebRequest,
                        ResponseCallback = asyncState.ResponseCallback,
                        State = asyncState.State
                    });
                }
                catch (Exception ex)
                {
                    if (asyncState != null)
                        asyncState.ResponseCallback(new HttpWebRequestCallbackState(ex));
                    else
                        throw;
                }
                finally
                {
                    if (requestStream != null)
                        requestStream.Dispose();
                }

            }).ConfigureAwait(false);
        }

        private static void BeginGetResponseCallback(IAsyncResult asyncResult)
        {
            WebResponse webResponse = null;
            Stream responseStream = null;
            HttpWebRequestAsyncState asyncState = null;

            try
            {
                asyncState = (HttpWebRequestAsyncState)asyncResult.AsyncState;
                webResponse = asyncState.HttpWebRequest.EndGetResponse(asyncResult);
                responseStream = webResponse.GetResponseStream();

                var webRequestCallbackState = new HttpWebRequestCallbackState(responseStream, asyncState.State);
                asyncState.ResponseCallback(webRequestCallbackState);

                responseStream.Dispose();
                webResponse.Dispose();
            }
            catch (Exception ex)
            {
                if (asyncState != null)
                    asyncState.ResponseCallback(new HttpWebRequestCallbackState(ex));
                else
                    throw;
            }
            finally
            {
                if (responseStream != null)
                    responseStream.Dispose();

                if (webResponse != null)
                    webResponse.Dispose();
            }
        }

    }
}