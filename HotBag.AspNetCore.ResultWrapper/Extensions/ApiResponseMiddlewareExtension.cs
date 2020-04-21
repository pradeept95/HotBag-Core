using Microsoft.AspNetCore.Builder;

namespace HotBag.AspNetCore.ResultWrapper.Extensions
{
    /// <summary>
    /// middleware helper extension class
    /// </summary>
    public static class ApiResponseMiddlewareExtension
    {
        public static IApplicationBuilder UseHotBagResultWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<APIResponseMiddleware>();
        }
    }
}
