using game.character.inventory;
using SFML.Graphics;

namespace game.character;

interface ICharacter
{
    ICharacterStatistics Statistics { get; }
    IInventory Inventory { get; }

    Texture Avatar { get; }

}
