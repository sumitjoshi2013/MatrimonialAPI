using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Utility
{
    public class CustomErrorResult : IHttpActionResult
    {
        private readonly string _errorMessage;
        private readonly HttpRequestMessage _requestMessage;
        private readonly HttpStatusCode _statusCode;

        public CustomErrorResult(HttpRequestMessage requestMessage,
           HttpStatusCode statusCode, string errorMessage)
        {
            _requestMessage = requestMessage;
            _statusCode = statusCode;
            _errorMessage = errorMessage;
        }

        
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_requestMessage.CreateErrorResponse(_statusCode, _errorMessage));
        }
    }

}