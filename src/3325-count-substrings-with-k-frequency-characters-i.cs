public class Solution3325
{
  public int NumberOfSubstrings(string s, int k)
  {
    Dictionary<char, int> counts = new();
    int total = 0;
    for (int i = 0, j = 0; i < s.Length; i++)
    {
      char c = s[i];
      counts[c] = counts.GetValueOrDefault(c, 0) + 1;
      while (counts[c] >= k)
      {
        total += s.Length - i;
        counts[s[j]]--;
        j++;
      }
    }
    return total;
  }
}
