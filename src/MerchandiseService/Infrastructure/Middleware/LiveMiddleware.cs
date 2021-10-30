using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middleware
{
	public class LiveMiddleware
	{
		private RequestDelegate _next;
		public LiveMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			await context.Response.WriteAsync("Alive");
		}
	}
}