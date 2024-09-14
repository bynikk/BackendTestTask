using System.Net;
using BackendTestTask.API.Builders;
using BackendTestTask.BusinessLogic.Exceptions;
using BackendTestTask.BusinessLogic.Models;
using BackendTestTask.BusinessLogic.Services;
using Microsoft.AspNetCore.Diagnostics;

namespace BackendTestTask.API.Middlewares;

public static class ExceptionMiddlewareExtension
{
    public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                var correlationId = context.Items["CorrelationId"]?.ToString();
                var correlationIdParseResult = Guid.TryParse(correlationId, out var correlationIdGuid);
                if (!correlationIdParseResult)
                {
                    correlationIdGuid = Guid.Empty;
                }

                var cancellationToken = context.RequestAborted;

                if (contextFeature is not null)
                {
                    switch (contextFeature.Error)
                    {
                        case SecureException:

                            var createModel = new SecurityExceptionLogCreateModel()
                            {
                                CorrelationId = correlationIdGuid,
                                ExceptionName = "Secure",
                                ExeptionMessage = contextFeature.Error.Message,
                            };

                            using (var scope = app.ApplicationServices.CreateScope())
                            {
                                var securityExceptionLogService = scope.ServiceProvider.GetRequiredService<ISecurityExceptionLogService>();
                                await securityExceptionLogService.Add(createModel, cancellationToken);
                            }

                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            await context.Response.WriteAsJsonAsync(ExceptionResponseBuilder.Build(
                                "Secure",
                                correlationIdGuid,
                                contextFeature.Error.Message));

                            break;

                        case Exception:
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            await context.Response.WriteAsJsonAsync(ExceptionResponseBuilder.Build(
                                "Exception",
                                correlationIdGuid,
                                contextFeature.Error.Message));
                            break;
                    }
                }
            });
        });
    }
}
