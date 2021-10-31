using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middleware
{
	public class ResponseLoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ResponseLoggingMiddleware> _logger;

		public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			await _next(context);
			await LogResponse(context);
		}

		private async Task LogResponse(HttpContext context)
		{
			try
			{
				var headers = string.Join(',', context.Response.Headers);
				var route = context.Request.Path;
				_logger.LogInformation(
					$"Response logged" +
					$"\nHeaders: {headers}" +
					$"\nPath: {route}");
			}
			catch (Exception e)
			{
				_logger.LogError($"Could not log response. Exception: {e.Message}");
			}
			
		}
	}
}