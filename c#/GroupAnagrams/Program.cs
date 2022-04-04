using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

class Program
{
  public static List<List<string>> groupAnagrams(List<string> words)
  {
    HashSet<AnagramGroup> anagramGroups = new HashSet<AnagramGroup>(words.Count, new AnagramGroupEqualityComparer());

    foreach (var word in words)
    {
      var tempAnagram = new AnagramGroup(word);

      if (anagramGroups.TryGetValue(tempAnagram, out AnagramGroup currentAnagramGroup))
      {
        currentAnagramGroup.Anagrams.Add(word);
      }
      else
      {
        anagramGroups.Add(tempAnagram);
      }
    }

    return anagramGroups.Select(e => e.Anagrams).ToList();
  }


  public class AnagramGroup
  {
    private readonly int _hashCode;

    public IList<char> SampleAnagram { get; private set; } = new List<char>();
    public List<string> Anagrams { get; private set; } = new List<string>();

    public AnagramGroup(string anagram)
    {
      _hashCode = GenerateHashCode(anagram);
      SampleAnagram = anagram.OrderBy(e => e).ToList();
      Anagrams.Add(anagram);
    }

    public override int GetHashCode()
    {
      return _hashCode;
    }

    private int GenerateHashCode(string anagram)
    {
      int genHashCode = 3;
      foreach (var c in anagram.OrderBy(e => e))
      {
        genHashCode += (genHashCode * 7) + (int)c;
      }

      return genHashCode;
    }
  }

  public class AnagramGroupEqualityComparer : IEqualityComparer<AnagramGroup>
  {
    public bool Equals(AnagramGroup x, AnagramGroup y)
    {
      return x?.SampleAnagram.Count == y?.SampleAnagram.Count && x?.GetHashCode() == y?.GetHashCode();
    }

    public int GetHashCode([DisallowNull] AnagramGroup obj)
    {
      return obj.GetHashCode();
    }
  }
}
