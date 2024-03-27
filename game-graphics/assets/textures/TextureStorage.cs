using SFML.Graphics;

namespace game_contracts.assets.textures;

internal class TextureStorage
{
    public static TextureStorage Instance = new TextureStorage();
    private TextureStorage() { }

    public Lazy<Texture> NoItemTexture = new Lazy<Texture>(() => new Texture("assets/textures/buttons/noitem.png"));
}


