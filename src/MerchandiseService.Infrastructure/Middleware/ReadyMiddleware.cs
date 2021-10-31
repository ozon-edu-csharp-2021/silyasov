using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middleware
{
	public class ReadyMiddleware
	{
		private RequestDelegate _next;
		public ReadyMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			await context.Response.WriteAsync("Ready");
		}
	}
}