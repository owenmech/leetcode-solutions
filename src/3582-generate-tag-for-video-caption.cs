public class Solution
{
  public string GenerateTag(string caption)
  {
    StringBuilder res = new StringBuilder().Append("#");
    bool capitalize = false;
    for (int i = 0; i < caption.Length; i++)
    {
      if (res.Length >= 100) break;
      char c = caption[i];
      if (c == ' ' && res.Length > 1)
      {
        capitalize = true;
      }
      else if (c >= 'a' && c <= 'z')
      {
        res.Append((char)(capitalize ? c - 'a' + 'A' : c));
        capitalize = false;
      }
      else if (c >= 'A' && c <= 'Z')
      {
        res.Append((char)(capitalize ? c : c - 'A' + 'a'));
        capitalize = false;
      }
    }
    return res.ToString();
  }
}
