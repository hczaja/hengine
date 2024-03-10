namespace game.character;

internal class CharacterStatistics : ICharacterStatistics
{
    public float MaxHealth => 50f;

    public float MaxEnergy => 50f;

    public int Strength => 1;

    public int Dexterity => 5;

    public int Endurance => 2;

    public int Charisma => 3;

    public int Wisdom => 2;

    public int Inteligence => 2;

    public float GetEnergy()
    {
        return MaxEnergy / 2f;
    }

    public float GetHealth()
    {
        return MaxHealth / 3f;
    }
}
