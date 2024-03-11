using SFML.Graphics;

namespace game.character.inventory.items;

class Item
{
    public string Name { get; }
    public ItemType Type { get; }

    public Texture Texture { get; }

    public Item(string name, ItemType type)
    {
        Name = name;
        Type = type;

        Texture = new Texture("assets/textures/buttons/campfire.png");
    }
}
