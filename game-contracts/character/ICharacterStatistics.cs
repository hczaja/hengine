namespace game_contracts.character;

public interface ICharacterStatistics
{
    float MaxHealth { get; }
    float GetHealth();

    float MaxEnergy { get; }
    float GetEnergy();

    int Strength { get; }
    int Dexterity { get; }
    int Endurance { get; }
    int Charisma { get; }
    int Wisdom { get; }
    int Inteligence { get; }
}
