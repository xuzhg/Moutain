using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ConsoleApplication
{
	public class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.Run(context => context.Response.WriteAsync("Hello World!"));
		}
	}
}