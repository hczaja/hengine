using game.character.diary;
using game.character.inventory;
using SFML.Graphics;

namespace game.character;

interface ICharacter
{
    ICharacterStatistics Statistics { get; }
    IInventory Inventory { get; }
    IDiary Diary { get; }

    Texture Avatar { get; }

}
