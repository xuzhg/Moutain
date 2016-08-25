using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
			  .UseKestrel()
			  .UseStartup<Startup>()
			  .Build()
			  .Run();
        }
    }
}
