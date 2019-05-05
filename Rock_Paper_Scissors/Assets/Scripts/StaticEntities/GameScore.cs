public static class GameScore
{
    private static byte PlayerScore;
    private static byte ComputerScore;
    public static byte NumberOfMatches;

    static GameScore()
    {
        NumberOfMatches = 3;
        ResetScore();
    }

    public static void ResetScore()
    {
        PlayerScore = 0;
        ComputerScore = 0;
    }
    public static byte GetPlayerScore() { return PlayerScore; }
    public static byte GetComputerScore() { return ComputerScore; }
    public static void PlayerWon() { PlayerScore++; }
    public static void ComputerWon() { ComputerScore++; }
    public static string FinalResult()
    {
        return PlayerScore > ComputerScore ? "You Win!" : PlayerScore < ComputerScore ? "You Lose" : "Tie";
    }
}