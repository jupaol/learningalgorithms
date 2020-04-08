using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.Middlewares
{
	public class HttpCodeAndLogMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<HttpCodeAndLogMiddleware> _logger;

		public HttpCodeAndLogMiddleware(RequestDelegate next, ILogger<HttpCodeAndLogMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

#pragma warning disable S4261 // Methods should be named according to their synchronicities
#pragma warning disable RCS1046 // Asynchronous method name should end with 'Async'.
		public async Task Invoke(HttpContext httpContext)
#pragma warning restore RCS1046 // Asynchronous method name should end with 'Async'.
#pragma warning restore S4261 // Methods should be named according to their synchronicities
		{
			if (httpContext == null)
			{
				return;
			}

			try
			{
				await _next(httpContext);
			}
			catch (NotFoundException exception)
			{
				await WriteAndLogResponseAsync(
					exception,
					httpContext,
					HttpStatusCode.NotFound,
					LogLevel.Warning);
			}
			catch (ValidationException exception)
			{
				await WriteAndLogResponseAsync(
					exception,
					httpContext,
					HttpStatusCode.UnprocessableEntity,
					LogLevel.Warning);
			}
			catch (Exception exception)
			{
				await WriteAndLogResponseAsync(
					exception,
					httpContext,
					HttpStatusCode.InternalServerError,
					LogLevel.Error,
					"Server error!");
			}
		}

		private async Task WriteAndLogResponseAsync(
			Exception exception,
			HttpContext httpContext,
			HttpStatusCode httpStatusCode,
			LogLevel logLevel,
			string alternateMessage = null)
		{
			_logger.Log(logLevel, exception, exception.Message);

			if (httpContext.Response.HasStarted)
			{
				_logger.LogError("The response has already started, the http status code middleware will not be executed.");

				return;
			}

			string responseMessage = JsonConvert.SerializeObject(
				new
				{
					Message = string.IsNullOrWhiteSpace(alternateMessage) ? exception.Message : alternateMessage
				});

			httpContext.Response.Clear();
			httpContext.Response.ContentType = ContentTypes.Json;
			httpContext.Response.StatusCode = (int)httpStatusCode;
			await httpContext.Response.WriteAsync(responseMessage, Encoding.UTF8);
		}
	}
}
