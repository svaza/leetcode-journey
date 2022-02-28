using System;
using System.Collections.Generic;
using static System.Console;

public class Program
{
  public class DoublyLinkedList
  {
    public Node Head;
    public Node Tail;

    public void SetHead(Node node)
    {
      WriteLine($"set head {node.Value}");
      if (Head != null)
        InsertBefore(Head, node);
      else
      {
        Head = node;
        Tail = node;
      }
    }

    public void SetTail(Node node)
    {
      WriteLine($"set tail {node.Value}");
      if(Tail != null)
      {
        InsertAfter(Tail, node);
      }
      else
      {
        Tail = node;
        Head = node;
      }
    }

    public void InsertBefore(Node node, Node nodeToInsert)
    {
      WriteLine($"insert before {node?.Value}");
      DetachNode(nodeToInsert);

      nodeToInsert.Next = node;
      nodeToInsert.Prev = node?.Prev;

      if (node?.Prev?.Next != null)
      {
        node.Prev.Next = nodeToInsert;
      }

      if (node != null)
      {
        node.Prev = nodeToInsert;
      }

      if (Head == node) Head = nodeToInsert;
    }

    public void InsertAfter(Node node, Node nodeToInsert)
    {
      WriteLine($"insert after {node.Value}");
      DetachNode(nodeToInsert);
      if(node?.Next?.Prev != null) 
      {
        node.Next.Prev = nodeToInsert;
      }
      nodeToInsert.Next = node.Next;
      nodeToInsert.Prev = node;
      node.Next = nodeToInsert;
      
      if (Tail == node)
      {
        Tail = nodeToInsert;
      }
    }

    public void InsertAtPosition(int position, Node nodeToInsert)
    {
      WriteLine($"InsertAtPosition {position} - value = {nodeToInsert.Value}");
      if (Head == null && Tail == null && position == 1)
      {
        Head = nodeToInsert;
        Tail = nodeToInsert;
      }
      else
      {
        Node node = Head;
        // 4->3->1
        while (position-- > 1)
        {
          node = node.Next;
        }
        InsertBefore(node, nodeToInsert);
      }

    }

    public void RemoveNodesWithValue(int value)
    {
      WriteLine($"RemoveNodesWithValue = {value}");

      Node node = Head;
      List<Node> nodesToBeRemoved = new List<Node>();
      while (node != null)
      {
        if (node.Value == value)
        {
          nodesToBeRemoved.Add(node);
        }
        node = node.Next;
      }

      nodesToBeRemoved.ForEach(n => DetachNode(n));
    }

    public void Remove(Node node)
    {
      WriteLine($"Remove = {node.Value}");

      DetachNode(node);
    }

    public bool ContainsNodeWithValue(int value)
    {
      WriteLine($"ContainsNodeWithValue = {value}");

      Node node = Head;
      while (node != null)
      {
        if (node.Value == value)
        {
          return true;
        }
        node = node.Next;
      }
      return false;
    }

    private void DetachNode(Node node)
    {
      if (node.Prev != null && node.Next != null && node != Head && node != Tail)
      {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
      }
      else if(node == Head)
      {
        Head = node.Next;
        if(Head?.Prev != null)
          Head.Prev = null;
      }
      else if(node == Tail)
      {
        Tail = node.Prev;
        if(Tail?.Next != null)
          Tail.Next = null;
      }
    }

  }

  // Do not edit the class below.
  public class Node
  {
    public int Value;
    public Node Prev;
    public Node Next;

    public Node(int value)
    {
      this.Value = value;
    }
  }

  public static void Main(string[] args)
  {
    int i = 5;
    while (i-- >= 1)
    {
      WriteLine("Hello World");
    }

  }
}
