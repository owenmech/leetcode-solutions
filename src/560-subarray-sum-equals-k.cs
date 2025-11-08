public class Solution
{
  public int SubarraySum(int[] nums, int k)
  {
    int[] sums = new int[nums.Length];
    int total = 0;
    Dictionary<int, int> sumCounts = new();

    for (int i = 0; i < nums.Length; i++)
    {
      sums[i] = (i == 0) ? nums[i] : nums[i] + sums[i - 1];
      if (sums[i] == k) total++;

      int needs = sums[i] - k;
      if (sumCounts.TryGetValue(needs, out int count))
      {
        total += count;
      }

      sumCounts[sums[i]] = sumCounts.GetValueOrDefault(sums[i]) + 1;
    }

    return total;
  }
}
