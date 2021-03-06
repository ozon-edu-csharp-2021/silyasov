using MediatR;
using MerchandiseService.Api.GrpcServices;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces;
using MerchandiseService.Infrastructure.Interceptors;
using MerchandiseService.Infrastructure.MediatR.Handlers;
using MerchandiseService.Infrastructure.Services;
using MerchandiseService.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MerchandiseService.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddSingleton<IEmployeeRepository, EmployeeRepositoryStub>();
	        services.AddSingleton<IMerchPackRepository, MerchPackRepositoryStub>();
	        services.AddSingleton<IMerchService, MerchService>();
	        services.AddMediatR(typeof(MerchRequestHandler));
	        services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
	        if (env.IsDevelopment())
		        app.UseDeveloperExceptionPage();
		
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
	            endpoints.MapControllers();
	            endpoints.MapGrpcService<MerchandiseGrpcService>();
            });
        }
    }
}
