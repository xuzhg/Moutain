
public class LinkedList : IEnumerable
{
	public LinkedListNode First {get; private set;}
	public LinkedListNode Last {get; private set; }
	
	public LinkedListNode AddLast(object value)
	{
		var newNode = new LinkedListNode(value);
		if (First == null)
		{
			First = newNode;
			Last = First;
		}
		else
		{
			LinkedListNode previous = Last;
			Last.Next = newNode;
			Last = newNode;
			Last.Prev = previous;
		}
		
		return newNode;
	}
	
	public IEnumerable GetEnumerator()
	{
		LinkedListNode current = First;
		while(current != null)
		{
			yield return current.Value;
			current = current.Next;
		}
	}
}