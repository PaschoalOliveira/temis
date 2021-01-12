using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace temis.Api.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IDistributedCache _cacheRedis;
        private const string ProcessKey = "Process";

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IDistributedCache cacheRedis)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
            _cacheRedis = cacheRedis;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                var info =  $"Request {context.Request?.Method}, {context.Request?.Path.Value} => {context.Response?.StatusCode}";
               _logger.LogInformation(info);
            }
            _cacheRedis.SetString(ProcessKey, "qualqer coisa");
        }
    }
}