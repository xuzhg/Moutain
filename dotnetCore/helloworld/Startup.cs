using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApplication
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			// app.Run(context => context.Response.WriteAsync("Hello World!"));
			app.UseMvc();
		}
		
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}
	}
}