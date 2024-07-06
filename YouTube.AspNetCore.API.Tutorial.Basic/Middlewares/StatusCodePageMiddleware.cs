using YouTube.AspNetCore.API.Tutorial.Basic.Models.Others;

namespace YouTube.AspNetCore.API.Tutorial.Basic.Middlewares
{
    public static class StatusCodePageMiddleware
    {
        public static void UseCustomStatusCodePages(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(async context =>
            {
                var statusCode = context.HttpContext.Response.StatusCode;
                if (statusCode is 401)
                    await context.HttpContext.Response.WriteAsJsonAsync(
                        CustomResponseDto<NoContentDto>.Fail(statusCode, "Unauthorized Access")
                        );
                if (statusCode is 403)
                    await context.HttpContext.Response.WriteAsJsonAsync(
                        CustomResponseDto<NoContentDto>.Fail(statusCode, "Permission Needed")
                        );
                if (statusCode is 404)
                    await context.HttpContext.Response.WriteAsJsonAsync(
                        CustomResponseDto<NoContentDto>.Fail(statusCode, "Page Not Found")
                        );
            });
        }
    }
}
