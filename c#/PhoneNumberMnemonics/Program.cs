using System.Collections.Generic;
using System;

public class Program
{

  public List<string> PhoneNumberMnemonics(string phoneNumber)
  {
    
    var mnemonicsMap = BuildMnemonics();
    var phoneNumberMnemonics = new List<string>();

    Traverse(phoneNumber.ToCharArray(), mnemonicsMap, new List<char>(phoneNumber.Length), phoneNumberMnemonics, 0);

    return phoneNumberMnemonics;
  }

  public void Traverse(char[] phoneNumber, Dictionary<char, List<char>> mnemonicsMap, List<char> currentMnemonic, List<string> phoneNumberMnemonics, int nextIdx)
  {
    if(currentMnemonic.Count == phoneNumber.Length)
    {
      phoneNumberMnemonics.Add(string.Join(null, currentMnemonic));
      return;
    }

    for(int idx = nextIdx; idx < phoneNumber.Length; idx++)
    {
      foreach(var m in mnemonicsMap[phoneNumber[idx]])
      {
        currentMnemonic.Add(m);
        Traverse(phoneNumber, mnemonicsMap, currentMnemonic, phoneNumberMnemonics, idx + 1);
        currentMnemonic.RemoveAt(currentMnemonic.Count - 1);
      }
    }
  }

  private Dictionary<char, List<char>> BuildMnemonics()
  {
    return new Dictionary<char, List<char>>()
    {
      { '1', new List<char>() { '1' } },
      { '0', new List<char>() { '0' } },
      { '2', new List<char>() { 'a', 'b', 'c' } },
      { '3', new List<char>() { 'd', 'e', 'f' } },
      { '4', new List<char>() { 'g', 'h', 'i' } },
      { '5', new List<char>() { 'j', 'k', 'l' } },
      { '6', new List<char>() { 'm', 'n', 'o' } },
      { '7', new List<char>() { 'p', 'q', 'r', 's' } },
      { '8', new List<char>() { 't', 'u', 'v' } },
      { '9', new List<char>() { 'w', 'x', 'y', 'z' } }
    };
  }
}

