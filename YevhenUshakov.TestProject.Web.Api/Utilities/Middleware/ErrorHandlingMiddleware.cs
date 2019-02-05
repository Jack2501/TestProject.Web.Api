﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using YevhenUshakov.TestProject.Model.Exceptions;
using YevhenUshakov.TestProject.Web.Api.Model;

namespace YevhenUshakov.TestProject.Web.Api.Utilities.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var exceptionType = exception.GetType();

                LogException(exceptionType, exception);

                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    await HandleUnauthorizedAccessException(context);
                }
                else
                {
                    await HandleExceptionAsync(context, exception);
                }
            }
        }

        protected virtual Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new ApiResponse(-1, exception.Message);

            if (exception is BusinessException businessException)
            {
                response.Status = businessException.Status;
                response.Description = response.Description.Contains(nameof(BusinessException)) ? businessException.Description : response.Description;
            }

            var model = JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            return context.Response.WriteAsync(model);
        }

        protected virtual Task HandleUnauthorizedAccessException(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            return Task.FromResult(0);
        }

        private void LogException(Type exceptionType, Exception exception)
        {
            if (exceptionType != typeof(BusinessException) && exceptionType != typeof(UnauthorizedAccessException))
            {
                _logger.LogError(exception, exception.Message);
            }
        }
    }
}
