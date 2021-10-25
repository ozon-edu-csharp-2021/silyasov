﻿using System;
using System.IO;
using System.Reflection;
using MerchandiseService.Infrastructure.StartupFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MerchandiseService.Infrastructure.Extensions
{
	public static class HostBuilderExtensions
	{
		public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{
				services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                
				//services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
				/*services.AddSwaggerGen(options =>
				{
					options.SwaggerDoc("v1", new OpenApiInfo {Title = "OzonEdu.StockApi", Version = "v1"});
                
					options.CustomSchemaIds(x => x.FullName);

					var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
					var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
					options.IncludeXmlComments(xmlFilePath);

					options.OperationFilter<HeaderOperationFilter>();
				});*/
			});
			return builder;
		}
        
		public static IHostBuilder AddHttp(this IHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{
				//services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
			});
            
			return builder;
		}
	}
}