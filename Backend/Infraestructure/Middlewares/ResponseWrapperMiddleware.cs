using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Domain.Exceptions;
using Infraestructure.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infraestructure.Middlewares
{
    public class ResponseWrapperMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseWrapperMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            try
            {
                using (var responseBodyStream = new MemoryStream())
                {
                    context.Response.Body = responseBodyStream;
                    await _next(context);

                    if (context.Response.StatusCode != StatusCodes.Status204NoContent)
                    {
                        responseBodyStream.Seek(0, SeekOrigin.Begin);
                        var responseBody = await new StreamReader(responseBodyStream).ReadToEndAsync();
                        var responseObject = JsonConvert.DeserializeObject(responseBody);

                        BaseResponse baseResponse;

                        if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300)
                        {
                            baseResponse = new BaseResponse(true, "Request succeeded", responseObject);
                        }
                        else
                        {
                            baseResponse = new BaseResponse(false, "Request failed", responseObject);
                        }

                        var jsonResponse = JsonConvert.SerializeObject(baseResponse);
                        context.Response.ContentType = "application/json";
                        context.Response.Body = originalBodyStream;
                        await context.Response.WriteAsync(jsonResponse);
                    }
                    else
                    {
                        context.Response.Body = originalBodyStream;
                    }
                }
            }
            catch (Exception exception)
            {
                context.Response.Body = originalBodyStream;
                context.Response.ContentType = "application/json";
                int status;
                string message;

                switch (exception)
                {
                    case BookNotFoundException e:
                        status = e.HttpStatusCode;
                        message = exception.Message;
                        break;

                    default:
                        status = 500;
                        message = "An unexpected error occurred.";
                        break;
                }

                context.Response.StatusCode = status;
                var response = new BaseResponse(false, message, null);
                var result = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(result);
            }
        }
    }
}
