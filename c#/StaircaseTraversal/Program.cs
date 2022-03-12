using System;


public class Program
{

  public int StaircaseTraversal(int height, int maxSteps)
  {
    int currentCounter = 0;
    int totalCount = 0;
    Traverse(height, maxSteps, ref currentCounter, ref totalCount);
    return totalCount;
  }

  public void Traverse(int height, int maxSteps, ref int currentStepCount, ref int totalCount)
  {
    if (currentStepCount == height)
    {
      totalCount++;
      return;
    }
    else if (currentStepCount > height)
    {
      return;
    }

    for (int idx = 1; idx <= maxSteps; idx++)
    {
      currentStepCount += idx;
      Traverse(height, maxSteps, ref currentStepCount, ref totalCount);
      currentStepCount -= idx;
    }
  }
}

