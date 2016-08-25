using System;
using System.IO;
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
			  .UseContentRoot(Directory.GetCurrentDirectory())
			  .UseUrls("http://localhost:8888/", "http://localhost:9999/")
			  .Build()
			  .Run();
        }
    }
}
