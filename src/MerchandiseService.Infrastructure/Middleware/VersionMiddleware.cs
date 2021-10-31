using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middleware
{
	public class VersionMiddleware
	{
		private RequestDelegate _next;
		public VersionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
			await context.Response.WriteAsync(version);
		}
	}
}