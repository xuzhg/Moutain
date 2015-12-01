using System;

namespace Wrox
{
	public class Program
	{
		static void Main(string[] args)
		{
			var name = "Bugs Bunny";
			var age = 25;
			var isRabbit = true;
			
			Type nameType = name.GetType();			
			Type ageType = age.GetType();
			Type isRabbitType = isRabbit.GetType();
			
			Console.WriteLine("name is type " + nameType.ToString());
			Console.WriteLine("age is type " + ageType.ToString());
			Console.WriteLine("isRabbit is type " + isRabbitType.ToString());
			
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(i);
			}
			
			for (int i = 9; i >= 0; i--)
			{
				Console.WriteLine(i);
			}
		}
	}
}