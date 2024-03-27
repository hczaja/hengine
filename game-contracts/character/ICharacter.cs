using game_contracts.diary;
using game_contracts.inventory;

namespace game_contracts.character;

public interface ICharacter
{
    ICharacterStatistics Statistics { get; }
    IInventory Inventory { get; }
    IDiary Diary { get; }
}
