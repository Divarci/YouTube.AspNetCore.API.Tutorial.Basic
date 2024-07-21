using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using YouTube.AspNetCore.API.Tutorial.Basic.Exceptions;
using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Middlewares
{
    public static class ExceptionMiddleware
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        MapperException => 400,
                        ClientSideException => 400,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
