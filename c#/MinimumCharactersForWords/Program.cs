using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

public class Program
{

  public string[] MinimumCharactersForWords(string[] words)
  {

    Dictionary<char, int> distinctCharMap = new Dictionary<char, int>();

    foreach (var word in words)
    {
      Dictionary<char, int> currentWordCharMap = new Dictionary<char, int>();
      foreach (var c in word)
      {
        if (!currentWordCharMap.ContainsKey(c)) currentWordCharMap.Add(c, 1);
        else currentWordCharMap[c]++;
      }

      foreach (var kv in currentWordCharMap)
      {
        if (distinctCharMap.ContainsKey(kv.Key))
        {
          var existingCount = distinctCharMap[kv.Key];
          if (kv.Value > existingCount)
            distinctCharMap[kv.Key] = kv.Value;
        }
        else
          distinctCharMap.Add(kv.Key, kv.Value);
      }
    }

    List<string> minChars = new List<string>();
    foreach (var kv in distinctCharMap)
    {
      for (int i = 0; i < kv.Value; i++)
        minChars.Add(kv.Key.ToString());
    }

    return minChars.ToArray();
  }
}
