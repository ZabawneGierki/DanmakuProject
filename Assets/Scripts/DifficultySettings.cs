public static class DifficultySettings
{
    public static float GetDifficultySpeedMultiplier(Difficulty difficultyLevel)
    {
        return difficultyLevel switch
        {
            Difficulty.Easy => 0.75f,
            Difficulty.Normal => 1f,
            Difficulty.Hard => 1.25f,
            Difficulty.Lunatic => 1.5f,
            _ => 1f
        };
    }
}