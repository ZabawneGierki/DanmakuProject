using UnityEngine;

public enum CharacterName
{
    Reimu,
    Hatate,
    Alice,

}

public enum Difficulty
{
    Easy,
    Normal,
    Hard,
    Lunatic
}   
public static class DaneGracza
{
    public static CharacterName characterName = CharacterName.Reimu;
    public static Difficulty difficulty = Difficulty.Easy;

}
