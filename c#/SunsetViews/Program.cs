using System.Collections.Generic;
using System;
using System.Linq;

public class Program
{

  public List<int> SunsetViews(int[] buildings, string direction)
  {
    List<int> viewList = new List<int>(buildings.Length);

    int prevMaxHeightIndex = -1;
    SunsetIterator(buildings, direction, (idx, value) =>
    {
      if(prevMaxHeightIndex == -1)
      {
        prevMaxHeightIndex = idx;
        viewList.Add(idx);
        return;
      }

      if(value > buildings[prevMaxHeightIndex]) 
      {
        prevMaxHeightIndex = idx;
        viewList.Add(idx);
      }
    });

    viewList.Sort();
    return viewList;
  }


  private void SunsetIterator(int[] buildings, string direction, Action<int, int> iterationCallback)
  {
    if (direction == "EAST")
    {
      for (int i = buildings.Length - 1; i >= 0; i--)
      {
        iterationCallback(i, buildings[i]);
      }
    }
    else
    {
      for (int i = 0; i < buildings.Length; i++)
      {
        iterationCallback(i, buildings[i]);
      }
    }
  }

}

