using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Helper
{
    public static class HttpMethodHelper
    {
        public static HttpMethod HttpMethodFromString(string method)
        {
            return method?.Trim().ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                "PATCH" => HttpMethod.Patch,
                "HEAD" => HttpMethod.Head,
                "OPTIONS" => HttpMethod.Options,
                "TRACE" => HttpMethod.Trace,
                _ => throw new ArgumentException($"Unsupported HTTP method: {method}")
            };
        }

        public static Method MethodFromString(string method)
        {
            return method?.Trim().ToUpper() switch
            {
                "GET" => Method.Get,
                "POST" => Method.Post,
                "PUT" => Method.Put,
                "DELETE" => Method.Delete,
                "PATCH" => Method.Patch,
                "HEAD" => Method.Head,
                "OPTIONS" => Method.Options,
                _ => throw new ArgumentException($"Unsupported HTTP method: {method}")
            };
        }
    }
}
