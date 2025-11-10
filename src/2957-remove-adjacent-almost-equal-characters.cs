public class Solution2957
{
  public int RemoveAlmostEqualCharacters(string word)
  {
    int total = 0;
    for (int i = 1; i < word.Length; i++)
    {
      if (Math.Abs(word[i] - word[i - 1]) <= 1)
      {
        total++;
        i++;
      }
    }
    return total;
  }
}
