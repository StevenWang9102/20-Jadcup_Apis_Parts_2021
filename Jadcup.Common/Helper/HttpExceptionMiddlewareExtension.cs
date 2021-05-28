using Microsoft.AspNetCore.Builder;
using Jadcup.Common.Error;

namespace Jadcup.Common.Helper {
    public static class HttpExceptionMiddlewareExtension {
        public static IApplicationBuilder UseHttpExceptionMiddleware(this IApplicationBuilder builder) {
//            builder.UseGoogleExceptionLogging();
            builder.UseMiddleware<HttpExceptionMiddleware>();
            return builder;
        }
    }
}