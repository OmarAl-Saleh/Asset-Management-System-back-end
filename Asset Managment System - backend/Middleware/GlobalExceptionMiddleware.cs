using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using NLog;
using AssetSystem.Common.Responses;

namespace Asset_Managment_System___backend.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unhandled exception caught by global middleware");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var errorMessage = string.IsNullOrWhiteSpace(exception.Message) ? "Unknown Error" : exception.Message;


            var result = WrappedOkObjectResultCls.Error(errorMessage);


            var json = System.Text.Json.JsonSerializer.Serialize(result.Value);

            return context.Response.WriteAsync(json);


        }
    }
}
