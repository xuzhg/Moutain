using System;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApplication
{
	public class HomeController
	{
		[HttpGet("/{name}")]
		public string Index(string name)
		{
			return $"Hello {name}";
		}
	}
}