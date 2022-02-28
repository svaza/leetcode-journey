using System;
using static System.Console;

public class Program {
	public static void RemoveKthNodeFromEnd(LinkedList head, int k) {
    LinkedList first = head;
    LinkedList second = head;

    while(k-- >= 1)
    {
      second = second.Next;
    }
		
		if(second == null)
		{
			first.Value = first.Next.Value;
			first.Next = first.Next.Next;
		}
		else
		{
			while(second.Next != null)
			{
				second = second.Next;
				first = first.Next;
			}

			first.Next = first.Next.Next;
		}
    
	}

	public class LinkedList {
		public int Value;
		public LinkedList Next = null;

		public LinkedList(int value) {
			this.Value = value;
		}
	}
}
