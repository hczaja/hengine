using game.character.inventory.items;

namespace game.character.inventory;

interface IInventory
{
    IEnumerable<Item> Backpack { get; }

    Item Weapon { get; }
    Item Armour { get; }
    Item Boots { get; }

    float GetCapacity();
    float MaxCapacity { get; }
}
