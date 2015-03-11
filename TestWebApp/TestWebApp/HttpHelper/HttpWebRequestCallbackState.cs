using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TestWebApp.HttpHelper
{
    public class HttpWebRequestCallbackState
    {
        public Stream ResponseStream { get; private set; }
        public Exception Exception { get; private set; }
        public Object State { get; set; }


        public HttpWebRequestCallbackState(Stream responseStream, object state)
        {
            ResponseStream = responseStream;
            State = state;
        }


        public HttpWebRequestCallbackState(Exception exception)
        {
            Exception = exception;
        }
    }
}