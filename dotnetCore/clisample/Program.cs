using System;
using System.Collections.Generic;
using NumberFun;
using Pets;

namespace ConsoleApplication
{
    public class Program
    {
		public static int FibonacciNumber(int n)
		{
			int a = 0;
			int b = 1;
			int tmp;
			
			for(int i = 0; i < n; i++)
			{
				tmp = a;
				a = b;
				b += tmp;
			}
			
			return a;
		}
		
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			Console.WriteLine("Fibonacci numers 1-15:");
			
			for(int i = 0; i < 15; i++)
			{
				Console.WriteLine($"{i+1}: {FibonacciNumber(i)}");
			}
			
			var generator = new FibonacciGenerator();
			foreach(var digit in generator.Generate(15))
			{
				Console.WriteLine(digit);
			}
			
			// Test the multiple folder
			List<IPet> pets = new List<IPet>
			{
				new Dog(),
				new Cat()
			};
			
			foreach(var pet in pets)
			{
				Console.WriteLine(pet.TalkToOwner());
			}
        }
    }
}
