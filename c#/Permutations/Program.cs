using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
  public static List<List<int>> GetPermutations(List<int> array)
  {
    var permutations = new List<List<int>>();
    for (int i = 0; i < array.Count; i++)
    {
      int elementPermuteCount = 0;
      while (elementPermuteCount < array.Count - 1 || (array.Count == 1 && elementPermuteCount < array.Count))
      {
        elementPermuteCount++;
        var currentPermutations = new List<int>();
        currentPermutations.Add(array[i]);
        var currentPermutationIndex = i == array.Count - 1 ? i - elementPermuteCount : i + elementPermuteCount;

        while (currentPermutations.Count < array.Count)
        {
          if (currentPermutationIndex >= array.Count) currentPermutationIndex = 0;
          if (currentPermutationIndex != i)
          {
            currentPermutations.Add(array[currentPermutationIndex]);
          }
          currentPermutationIndex++;
        }
        permutations.Add(currentPermutations);
      }

    }
    return permutations;
  }
}
