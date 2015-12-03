using System;

namespace Wrox
{
	public class ParameterTest
	{
		static void SomeFunction(int[] ints, int i, string str)
		{
			ints[0] = 100;
			i = 100;
			
			str = "AAAABBB";
		}
		
		public static void Main()
		{
			int i = 0;
			int[] ints = {0, 1, 2, 4, 8};
			
			// Display the original values
			Console.WriteLine("i = " + i);
			Console.WriteLine("ints[0] = " + ints[0]);
			Console.WriteLine("Calling SomeFunction ....");
			
			string astr = "111234";
			// After this method returns, ints will be changed,
			// but i will not.
			SomeFunction(ints, i, astr);
			Console.WriteLine("i = " + i);
			Console.WriteLine("ints[0] = " + ints[0]);
			Console.WriteLine("astr = " + astr);
		}
	}
}