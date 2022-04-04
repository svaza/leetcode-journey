using System;

public class Program
{
  public static string LongestPalindromicSubstring(string str)
  {
    (int StartIdx, int EndIdx) longestPalindrome = (0, 1);

    for (int idx = 0; idx < str.Length; idx++)
    {
      var oddPalindrome = GetLongestPalindromicStringAt(idx - 1, idx + 1, str);
      var evenPalindrome = GetLongestPalindromicStringAt(idx - 1, idx, str);

      longestPalindrome = Max(longestPalindrome, Max(oddPalindrome, evenPalindrome));
    }

    return str.Substring(longestPalindrome.StartIdx, longestPalindrome.EndIdx - longestPalindrome.StartIdx);
  }

  private static (int StartTdx, int EndIdx) GetLongestPalindromicStringAt(int leftIdx, int rightIdx, string str)
  {
    while (leftIdx >= 0 && rightIdx < str.Length)
    {
      if (str[leftIdx] != str[rightIdx])
      {
        break;
      }
      leftIdx--;
      rightIdx++;
    }

    return (leftIdx + 1, rightIdx);
  }

  private static (int StartIdx, int EndIdx) Max((int StartIdx, int EndIdx) t1, (int StartIdx, int EndIdx) t2)
  {
    if ((t1.EndIdx - t1.StartIdx) > (t2.EndIdx - t2.StartIdx)) return t1;
    else return t2;
  }

}



