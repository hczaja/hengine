using game.character.inventory.items;

namespace game.character.inventory;

class CharacterInventory : IInventory
{
    public CharacterInventory()
    {
        //Backpack = new 
    }

    public IEnumerable<Item> Backpack { get; } = new List<Item>()
    {
        new Item("test", ItemType.Valueable),
        new Item("test2", ItemType.Valueable),
        new Item("test", ItemType.Valueable),
        new Item("test2", ItemType.Valueable),
        new Item("test", ItemType.Valueable),
        new Item("test2", ItemType.Valueable),
        new Item("test", ItemType.Valueable),
        new Item("test2", ItemType.Valueable)
    };

    public Item Weapon => throw new NotImplementedException();

    public Item Armour => throw new NotImplementedException();

    public Item Boots => throw new NotImplementedException();

    public float MaxCapacity => throw new NotImplementedException();

    public float GetCapacity()
    {
        throw new NotImplementedException();
    }
}
