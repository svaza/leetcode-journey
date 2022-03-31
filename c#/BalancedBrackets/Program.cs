using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
  private static HashSet<char> tokenSetOpening = new HashSet<char>() { '(', '[', '{' };
  private static HashSet<char> tokenSetClosing = new HashSet<char>() { ')', ']', '}' };
  private static Dictionary<char, char> tokenMap = new Dictionary<char, char>()
  {
    { '{', '}' },
    { '[', ']' },
    { '(', ')' }
  };

  public static bool BalancedBrackets(string str)
  {

    Stack<char> tokens = new Stack<char>(str.Length);

    foreach (var c in str)
    {
      if (tokenSetOpening.Contains(c))
      {
        tokens.Push(c);
      }
      else if (tokenSetClosing.Contains(c) && tokens.Count() > 0)
      {
        var tokenSibling = tokens.Pop();
        if (c != tokenMap[tokenSibling])
        {
          return false;
        }
      }
      else if(tokenSetClosing.Contains(c) && tokens.Count() == 0)
      {
        return false;
      }
    }

    return tokens.Count == 0;
  }

  public static void Main(string[] args)
  {
    Console.WriteLine("Hello World");
  }
}
