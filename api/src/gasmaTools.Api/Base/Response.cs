using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace gasmaTools.Api.Base
{
    public class Response<TData> : StatusCodeResult
        where TData : class
    {
        public bool Success { get; set; }
        public TData Data { get; set; }
        public IEnumerable<string> Messages { get; set; }

        public Response(TData data, bool success, HttpStatusCode statusCode)
            : base((int)statusCode)
        {
            this.Data = data;
            this.Success = success;
        }

        public Response(TData data, bool success, HttpStatusCode statusCode, IEnumerable<string> messages)
            : this(data, success, statusCode)
        {
            this.Messages = messages;
        }
    }
}
