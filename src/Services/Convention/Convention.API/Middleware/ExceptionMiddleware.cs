using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Convention.BLL.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Convention.API.Middleware
{
    public class ExceptionMiddleware
    {
        private static readonly ILogger Logger = Log.ForContext<ExceptionMiddleware>();
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var modelStateDictionary = new ModelStateDictionary();
                foreach (var error in exception.Errors)
                {
                    modelStateDictionary.AddModelError(error.Key, error.Value.FirstOrDefault());
                }

                await WriteToResponseAsync(context, modelStateDictionary);
            }
            catch (Exception exception)
            {
                //TODO: return error id
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                Logger.Error(exception, exception.Message);
            }
        }

        private static async Task WriteToResponseAsync(HttpContext context, ModelStateDictionary modelState)
        {
            await WriteToResponseAsync(context, new SerializableError(modelState));
        }

        private static async Task WriteToResponseAsync(HttpContext context, object data)
        {
            var executor = context.RequestServices.GetRequiredService<IActionResultExecutor<ObjectResult>>();
            var ct = new ActionContext(context, context.GetRouteData(), new ActionDescriptor());
            await executor.ExecuteAsync(ct, new ObjectResult(data));
        }
    }
}