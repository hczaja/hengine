using game.character.inventory.items;

namespace game.character.inventory;

class CharacterInventory : IInventory
{
    public CharacterInventory()
    {
        //Backpack = new 
    }

    public IEnumerable<Item> Backpack => throw new NotImplementedException();

    public Item Weapon => throw new NotImplementedException();

    public Item Armour => throw new NotImplementedException();

    public Item Boots => throw new NotImplementedException();

    public float MaxCapacity => throw new NotImplementedException();

    public float GetCapacity()
    {
        throw new NotImplementedException();
    }
}
