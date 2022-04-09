using System.Collections.Generic;
using System.Text;

public class Program
{

  public string ReverseWordsInString(string str)
  {
    if (str.Length == 0) return str;

    const char space = (char)32;
    Stack<string> reverseWordsStack = new Stack<string>(str.Length);
    char previousChar = str[0];
    StringBuilder runningStr = new StringBuilder().Append(previousChar);
    for (int i = 1; i < str.Length; i++)
    {
      var currentChar = str[i];

      if ((previousChar == space && currentChar != space) || (previousChar != space && currentChar == space))
      {
        reverseWordsStack.Push(runningStr.ToString());
        runningStr.Clear();
      }

      runningStr.Append(currentChar);
      previousChar = currentChar;
    }

    if (runningStr.Length > 0) reverseWordsStack.Push(runningStr.ToString());

    runningStr.Clear();

    while (reverseWordsStack.Count > 0)
    {
      runningStr.Append(reverseWordsStack.Pop());
    }


    return runningStr.ToString();
  }
}

