using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Infrastructure.Middleware
{
	public class ReadyMiddleware
	{
		private RequestDelegate _next;
		public ReadyMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task<IActionResult> InvokeAsync(HttpContext context)
		{
			return null;
			//	Ok("Ready");
		}
	}
}