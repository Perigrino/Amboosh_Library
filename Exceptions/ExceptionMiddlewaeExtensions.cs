using System.Net;
using Amboosh_Library.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;

namespace Amboosh_Library.Exceptions;

public static class ExceptionMiddlewaeExtensions
{
    public static void ConfigureBuilderExpcetionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                var contextRequest = context.Features.Get<IHttpRequestFeature>();

                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new ErrorVM()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Path = contextRequest.Path
                    }.ToString());
                }
            });
        });
    }
}