public class Solution1590
{
	public int MinSubarray(int[] nums, int p)
	{
		int[] runningTotals = new int[nums.Length];
		Dictionary<int, int> lastSeen = new(); // key -> most recent running total mod p equal to key
		for (int i = 0; i < nums.Length; i++)
		{
			int total = (nums[i] % p + (i == 0 ? 0 : runningTotals[i - 1]) % p) % p;
			runningTotals[i] = total;
		}

		int toRemove = runningTotals[^1];
		if (toRemove == 0) return 0;
		int shortest = int.MaxValue;

		// find the shortest subarray whose sum is toRemove (mod p)
		for (int i = 0; i < nums.Length; i++)
		{
			if (runningTotals[i] == toRemove)
			{
				shortest = Math.Min(shortest, i + 1);
			}

			// [0, i] - [0, j] = (j, i]
			// the most recent [0, j] that makes the difference toRemove will give us the shortest
			int lookingFor = (runningTotals[i] - toRemove + p) % p;
			if (lastSeen.TryGetValue(lookingFor, out int j))
			{
				shortest = Math.Min(shortest, i - j);
			}


			lastSeen[runningTotals[i]] = i;
		}

		if (shortest >= nums.Length) return -1;
		return shortest;
	}
}
