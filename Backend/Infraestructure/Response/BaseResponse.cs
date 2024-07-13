using System;
namespace Infraestructure.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public BaseResponse(bool success, string message, object? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}

