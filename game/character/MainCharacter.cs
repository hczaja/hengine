﻿using game.character.diary;
using game.character.inventory;
using game_contracts.character;
using game_contracts.diary;
using game_contracts.inventory;
using SFML.Graphics;

namespace game.character;

class MainCharacter : ICharacter
{
    public Texture Avatar { get; } 

    public MainCharacter()
    {
        Statistics = new CharacterStatistics();
        Inventory = new CharacterInventory();
        Diary = new CharacterDiary();
    }

    public ICharacterStatistics Statistics { get; }

    public IInventory Inventory { get; }

    public IDiary Diary { get; }
}
