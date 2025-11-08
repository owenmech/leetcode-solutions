public class Solution2212
{
  public int[] MaximumBobPoints(int numArrows, int[] aliceArrows)
  {
    int[] bestArrows = new int[aliceArrows.Length];
    int bestScore = 0;
    int[] currentArrows = new int[aliceArrows.Length];

    void recurse(int checkTarget, int remaining, int currentScore)
    {
      if (remaining < 0) return;
      if (remaining == 0 || checkTarget <= 0)
      {
        if (currentScore > bestScore)
        {
          bestScore = currentScore;
          currentArrows.CopyTo(bestArrows, 0);
          bestArrows[0] += remaining;
        }
        return;
      }
      recurse(checkTarget - 1, remaining, currentScore);
      int required = aliceArrows[checkTarget] + 1;
      currentArrows[checkTarget] += required;
      recurse(checkTarget - 1, remaining - required, currentScore + checkTarget);
      currentArrows[checkTarget] -= required;
    }

    recurse(aliceArrows.Length - 1, numArrows, 0);

    return bestArrows;
  }
}
