using System;

namespace Wrox.ProCSharp
{
	class MathOperations
	{
		public static double MultipleByTwo(double value)
		{
			return value * 2;
		}
		
		public static double Square(double value)
		{
			return value * value;
		}
	}
	
	class MathOperations2
	{
		public static void MultipleByTwo(double value)
		{
			double result = value * 2;
			Console.WriteLine("Multiplying by 2: {0} gives {1}", value, result);
		}
		
		public static void Square(double value)
		{
			double result = value * value;
			Console.WriteLine("Square {0} gives {1}", value, result);
		}
	}
	
	delegate double DoubleOp(double x);
	
	class program
	{
		static void Main()
		{
			DoubleOp[] operations = 
			{
				MathOperations.MultipleByTwo,
				MathOperations.Square
			};
			
			for (int i = 0; i < operations.Length; i++)
			{
				Console.WriteLine("Using operations[{0}]: ", i);
				ProcessAndDisplayNumber(operations[i], 2.0);
				ProcessAndDisplayNumber(operations[i], 7.94);
				ProcessAndDisplayNumber(operations[i], 1.414);
				Console.WriteLine();
			}
			
			Action<double> operations2 = MathOperations2.MultipleByTwo;
			operations2 += MathOperations2.Square;
			
			ProcessAndDisplayNumber(operations2, 2.0);
			ProcessAndDisplayNumber(operations2, 7.94);
			ProcessAndDisplayNumber(operations2, 1.414);		
			
		}
		
		static void ProcessAndDisplayNumber(DoubleOp action, double value)
		{
			double result = action(value);
			Console.WriteLine("Value is {0}, result of operation is {1}", value, result);
		}
		
		static void ProcessAndDisplayNumber(Action<double> action, double value)
		{
			Console.WriteLine();			
			Console.WriteLine("ProcessAndDisplayNumber called with value = {0}", value);
			action(value);
		}
	}
}