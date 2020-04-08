using Microsoft.AspNetCore.Builder;

namespace Api.Middlewares
{
	public static class HttpStatusCodeExceptionMiddlewareExtensions
	{
		public static IApplicationBuilder UseHttpCodeAndLogMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<HttpCodeAndLogMiddleware>();
		}
	}
}
