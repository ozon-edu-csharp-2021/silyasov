using MerchandiseService.Infrastructure.Filters;
using MerchandiseService.Infrastructure.StartupFilters;
using MerchandiseService.Infrastructure.Swagger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MerchandiseService.Infrastructure.Extensions
{
	public static class HostBuilderExtensions
	{
		public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{
				services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
				services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
				
				services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
				
				services.AddSwaggerGen(options =>
				{
					options.SwaggerDoc("v1", new OpenApiInfo {Title = "MerchandiseService", Version = "v1"});
					options.CustomSchemaIds(x => x.FullName);
					options.OperationFilter<HeaderOperationFilter>();
				});
			});
			return builder;
		}
	}
}