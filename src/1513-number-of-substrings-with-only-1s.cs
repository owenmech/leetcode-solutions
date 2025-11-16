public class Solution1513
{
  public int NumSub(string s)
  {
    const int MOD = 1000000007;
    int curLen = 0;
    int total = 0;
    for (int i = 0; i < s.Length; i++)
    {
      char c = s[i];
      if (c == '1')
      {
        curLen++;
        total = (total + curLen) % MOD;
      }
      else
      {
        curLen = 0;
      }
    }
    return total;
  }
}
