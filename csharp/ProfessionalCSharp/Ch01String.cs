using System;

namespace Wrox
{
	public class Program
	{
		static void Main(string[] args)
		{
			string s1 = "a string";
			string s2 = s1;
						
			Console.WriteLine("s1 is " + s1);
			Console.WriteLine("s2 is " + s2);
			
			s1 = "another string";
			Console.WriteLine("s1 is " + s1);
			Console.WriteLine("s2 is " + s2);
		}
	}
}