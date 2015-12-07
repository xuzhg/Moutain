using System

public class LinkedListApp
{
	public static void Main()
	{
		var list = new LinkedList();
		list.AddLast(2);
		list.AddLast(4);
		list.AddLast("6");
		
		foreach(int i in list)
		{
			Console.WriteLine(i);
		}
	}
}