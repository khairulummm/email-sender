using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Helper
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode statusCode, string jsonError)
        {
            StatusCode = statusCode;
            JsonError = jsonError;
        }

        public HttpStatusCode StatusCode { get; private set; }
        public string JsonError { get; private set; }
    }
}
