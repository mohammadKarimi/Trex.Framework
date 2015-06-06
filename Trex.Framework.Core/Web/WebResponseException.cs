namespace Trex.Framework.Core.Web
{
    using System;
    using System.Net;
    public class WebResponseException : Exception
    {
        public WebResponseException()
        {
        }

        public WebResponseException(string message)
            : base(message)
        {

        }

        public WebResponseException(HttpStatusCode status, string message)
            : base(message)
        {
            this.Status = status;
        }

        public WebResponseException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public WebResponseException(HttpStatusCode status, string message, Exception innerException)
            : base(message, innerException)
        {
            this.Status = status;
        }

        public HttpStatusCode Status { get; set; }
    }
}
