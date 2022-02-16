using BLL.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cinema_WebApi.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpException httpError)
            {
                await CreateResponse(context, httpError.StatusCode, httpError.Message);
            }
            catch (KeyNotFoundException error)
            {
                await CreateResponse(context, HttpStatusCode.NotFound, error.Message);
            }
            catch (Exception error)
            {
                await CreateResponse(context, HttpStatusCode.InternalServerError, error?.Message);
            }
        }

        private async Task CreateResponse(HttpContext context,
                                    HttpStatusCode statusCode = HttpStatusCode.InternalServerError, 
                                    string message = "Unknown error type!")
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var result = JsonSerializer.Serialize(new { message });
            await context.Response.WriteAsync(result);
        }
    }
}
