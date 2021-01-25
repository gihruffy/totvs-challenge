using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TOTVSChallenge.Domain.ExceptionHandler
{
    public class TOTVSCustomExcepetion :Exception
    {

        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public TOTVSCustomExcepetion(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public TOTVSCustomExcepetion(HttpStatusCode statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        public TOTVSCustomExcepetion(HttpStatusCode statusCode, Exception inner)
            : this(statusCode, inner.ToString()) { }

        public TOTVSCustomExcepetion(HttpStatusCode statusCode, JObject errorObject)
            : this(statusCode, errorObject.ToString())
        {
            this.ContentType = @"application/json";
        }

    }
}
