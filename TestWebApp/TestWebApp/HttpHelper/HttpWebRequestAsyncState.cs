using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TestWebApp.HttpHelper
{
    public class HttpWebRequestAsyncState
    {
        public byte[] RequestBytes { get; set; }
        public HttpWebRequest HttpWebRequest { get; set; }
        public Action<HttpWebRequestCallbackState> ResponseCallback { get; set; }
        public Object State { get; set; }
    }
}