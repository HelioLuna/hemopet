using System;
using System.Net.Http;

namespace hemopet.Core.Services.Remote.RequestProvider
{
    public class HttpRequestExceptionEx : HttpRequestException
    {
        public System.Net.HttpStatusCode HttpCode { get; }
        public Endpoint Endpoint { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public HttpRequestExceptionEx(System.Net.HttpStatusCode code) : this(code, null, null)
        {
            HttpCode = code;
        }

        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string message) : this(code, message, null)
        {
            HttpCode = code;
        }

        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string message, Exception inner) : base(message, inner)
        {
            HttpCode = code;
        }

        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string message, Endpoint endpoint, HttpMethod httpMethod) : this(code, message, null)
        {
            HttpCode = code;
            Endpoint = endpoint;
            HttpMethod = httpMethod;
        }
    }
}
