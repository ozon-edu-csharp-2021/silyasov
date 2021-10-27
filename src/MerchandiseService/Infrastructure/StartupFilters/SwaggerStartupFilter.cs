using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MerchandiseService.Infrastructure.StartupFilters
{
	public class SwaggerStartupFilter : IStartupFilter
	{
		public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
		{
			return app =>
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.RoutePrefix = "";
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "Merchandise Service");
				});
				next(app);
			};
		}
	}
}