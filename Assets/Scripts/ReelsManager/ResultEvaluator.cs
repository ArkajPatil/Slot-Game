
public static class ResultEvaluator
{
    public static bool IsWinningCombination(int[] results)
    {
        if (results == null || results.Length != 3)
        {
            return false;
        }

        return ( results[0] == results[1] && results[1] == results[2] ) ;
    }
}
