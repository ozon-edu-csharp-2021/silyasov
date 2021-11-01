using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middleware
{
	public class RequestLoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<RequestLoggingMiddleware> _logger;

		public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			await LogRequest(context);
			await _next(context);
		}

		private async Task LogRequest(HttpContext context)
		{
			try
			{
				var headers = string.Join(',', context.Request.Headers);
				var path = context.Request.Path;
				
				_logger.LogInformation(
					$"Request logged" +
					$"\nHeaders: {headers}" +
					$"\nPath: {path}");
			}
			catch (Exception e)
			{
				_logger.LogError($"Could not log request. Exception: {e.Message}");
			}
		}
	}
}