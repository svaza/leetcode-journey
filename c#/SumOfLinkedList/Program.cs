using System.Collections.Generic;
using System;
using static System.Console;

public class Program
{
  // This is an input class. Do not edit.
  public class LinkedList
  {
    public int value;
    public LinkedList next;

    public LinkedList(int value)
    {
      this.value = value;
      this.next = null;
    }
  }

  public LinkedList SumOfLinkedLists(LinkedList linkedListOne, LinkedList linkedListTwo)
  {

    int carry = 0;
    LinkedList linkedListSumHead = null;
    LinkedList runningSum = null;
    while (linkedListOne != null || linkedListTwo != null || carry > 0)
    {
      int sum = (linkedListOne?.value ?? 0) + (linkedListTwo?.value ?? 0) + carry;
			
      if (sum > 9)
      {
				carry = sum / 10;
        sum = sum % 10;
      }
      else
      {
        carry = 0;
      }
			
      var localSum = new LinkedList(sum);
      if(runningSum != null) runningSum.next = localSum;
      runningSum = localSum;

      if(linkedListSumHead == null) linkedListSumHead = runningSum;
     
      linkedListOne = linkedListOne?.next;
      linkedListTwo = linkedListTwo?.next;
    }
		
    return linkedListSumHead;
  }
}

