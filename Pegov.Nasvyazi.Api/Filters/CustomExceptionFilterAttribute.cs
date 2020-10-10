using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using pegov.nasvayzi.Application.Common.Behaviours;
using pegov.nasvayzi.Application.Common.Exceptions;
using Raven.Client.Exceptions;
using Raven.Client.Exceptions.Security;
using Serilog;
using ConflictException = pegov.nasvayzi.Application.Common.Exceptions.ConflictException;
using InvalidOperationException = System.InvalidOperationException;

namespace pegov.nasvayzi.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException exception)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = ResultBadRequestFluentValidation(exception.Failures);
                return;
            }
            
            Log.Error(context.Exception, "An unhandled exception has occurred");

            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            if (context.Exception is ConflictException)
            {
                code = HttpStatusCode.Conflict;
            }

            if (context.Exception is AuthorizationException)
            {
                code = HttpStatusCode.Forbidden;
            }

            if (context.Exception is InvalidOperationException)
            {
                code = HttpStatusCode.InternalServerError;
            }

            if (context.Exception is BadRequestException)
            {
                code = HttpStatusCode.BadRequest;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = ResultException(context.Exception.Message, context.Exception.StackTrace, code);
        }

        #region private
        private IActionResult ResultBadRequestFluentValidation(IDictionary<string, string[]> exceptions)
        {
            var ex = new FluentValidationExceptionResponseBody()
                { Status = StatusCodes.Status400BadRequest };

            foreach (var (key, value) in exceptions)
            {
                ex.Errors.Add(Utility.ToCamelCase(key), value);
            }

            return new JsonResult(ex);
        }

        private IActionResult ResultBadRequest(IDictionary<string, string[]> exceptions)
        {
            var responseErrors = new List<string>();

            foreach (var exp in exceptions)
            {
                foreach (var value in exp.Value)
                {
                    responseErrors.Add(value);
                }
            }

            return new JsonResult(StatusCodes.Status400BadRequest);
        }

        private IActionResult ResultException(string message, string stackTrace, HttpStatusCode code)
        {
            var responseErrors = new List<string>();
            Log.Information($"{nameof(CustomExceptionFilterAttribute)} ResultException message: {message}");
            responseErrors.Add(message);

            return code switch
            {
                HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(
                    StatusCodes.Status401Unauthorized),
                HttpStatusCode.BadRequest => new BadRequestObjectResult(
                    StatusCodes.Status400BadRequest),
                HttpStatusCode.Conflict => new ConflictObjectResult(
                    StatusCodes.Status409Conflict),
                HttpStatusCode.NotFound => new NotFoundObjectResult(
                    StatusCodes.Status400BadRequest),
                HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(
                    StatusCodes.Status422UnprocessableEntity),
                HttpStatusCode.InternalServerError => new InternalServerErrorObjectResult(
                    StatusCodes.Status500InternalServerError),
                _ => new InternalServerErrorObjectResult(StatusCodes.Status500InternalServerError),
            };
        }
        #endregion
    }
}