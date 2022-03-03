using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
  public static List<List<int>> Powerset(List<int> array)
  {

    var powerSet = new List<List<int>>();
    powerSet.Add(new List<int>());
    for (int p = 0; p < array.Count; p++)
    {
      FindPowerSet(array, p + 1, powerSet, new HashSet<int>(), 0);
    }

    return powerSet;
  }

  public static void FindPowerSet(List<int> array, int power, List<List<int>> powerSet, HashSet<int> currentSet, int nextIdx)
  {
    if (currentSet.Count == power)
    {
      powerSet.Add(currentSet.ToList());
      return;
    }


    for (int i = nextIdx; i < array.Count; i++)
    {
      currentSet.Add(array[i]);
      FindPowerSet(array, power, powerSet, currentSet, i + 1);
      currentSet.Remove(array[i]);
    }
  }
}
