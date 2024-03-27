using game_contracts.inventory;
using SFML.Graphics;

namespace game_graphics.items;

class DrawableItem
{
    public Texture Texture { get; }

    public DrawableItem(Item item)
    {
        Texture = new Texture("assets/textures/buttons/campfire.png");
    }
}
