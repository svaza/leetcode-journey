using System.Collections.Generic;
using System;
using System.Text;


public class Program
{
  private const int ValidIPPartCount = 4;
  private const int PerPartLength = 3;

  public List<string> ValidIPAddresses(string str)
  {
    var ips = new List<string>();
    ParseIpParts(str, ips, new Stack<string>());
    return ips;
  }

  private void ParseIpParts(string str, List<string> ipList, Stack<string> ipPartStack)
  {
    if (string.IsNullOrEmpty(str) && ipPartStack.Count == ValidIPPartCount)
    {
      ipList.Add(GenerateIP(ipPartStack));
      return;
    }
    else if (ipPartStack.Count > ValidIPPartCount) return;

    for (int i = 1; i <= Math.Min(PerPartLength, str.Length); i++)
    {
      var ipPart = str.Substring(0, i);
      if (!IsValid(ipPart)) return;
      ipPartStack.Push(ipPart);
      var remainingPart = str.Substring(i, str.Length - i);
      ParseIpParts(remainingPart, ipList, ipPartStack);
      ipPartStack.Pop();
    }
  }

  private string GenerateIP(Stack<string> ipParts)
  {
    StringBuilder sb = new StringBuilder(40);
    var ipPartsArr = ipParts.ToArray();
    for (int idx = ipPartsArr.Length - 1; idx >= 0; idx--)
    {
      if (sb.Length > 0) sb.Append(".");
      sb.Append(ipPartsArr[idx]);
    }

    return sb.ToString();
  }

  private bool IsValid(string ipPart)
  {
    if (string.IsNullOrEmpty(ipPart)) return false;
    if (ipPart == "00") return false;
    if (ipPart.Length == 2 && ipPart[0] == '0') return false;
    if (int.Parse(ipPart) > 255) return false;
    return true;
  }
}

