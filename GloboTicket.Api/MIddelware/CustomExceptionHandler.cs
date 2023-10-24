using GloboTicket.Application.Exceptions;
using SendGrid;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace GloboTicket.Api.MIddelware
{
    public class CustomExceptionHandler
    {
        private RequestDelegate _next;

        public CustomExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception ex)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;
            switch (ex)
            {
                case Application.Exceptions.ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Message);
                    break;
                case Application.Exceptions.NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    result = notFoundException.Message;
                    break;
                case Application.Exceptions.BadRequestException BadException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = BadException.Message;
                    break;
                case Exception exception:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }
            context.Response.StatusCode = (int)httpStatusCode;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = "Error massage!!" });
            }

            return context.Response.WriteAsync(result);

        }
    }
}
