using System;

namespace Wrox
{
	class MainEntryPoint
	{
		static void Main()
		{
			// try calling some static functions.
			Console.WriteLine("Pi is " + MathTest.GetPi());
			int x = MathTest.GetSquareOf(5);
			Console.WriteLine("Square of 5 is " + x);
			
			// Instantiate a MathTest object
			MathTest math = new MathTest(); // this is C#'s way of instantiating a reference type
			math.value = 30;
			Console.WriteLine("Value field of math variable contains " + math.value);
			Console.WriteLine("Square of 30 is " + math.GetSquare());
		}
	}
	
	// define a class named MathTest on which we will call a method
	class MathTest
	{
		public int value;
		
		public int GetSquare()
		{
			return value * value;
		}
		
		public static int GetSquareOf(int x)
		{
			return x * x;
		}
		
		public static double GetPi()
		{
			return 3.1415926;
		}
	}
}