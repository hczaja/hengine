using game.character.diary;
using game.character.inventory;
using SFML.Graphics;

namespace game.character;

class MainCharacter : ICharacter
{
    public Texture Avatar { get; } 

    public MainCharacter()
    {
        Avatar = new Texture("assets/textures/avatars/cat.png");
        Statistics = new CharacterStatistics();
        Inventory = new CharacterInventory();
        Diary = new CharacterDiary();
    }

    public ICharacterStatistics Statistics { get; }

    public IInventory Inventory { get; }

    public IDiary Diary { get; }
}
