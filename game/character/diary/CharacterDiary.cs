namespace game.character.diary;

class CharacterDiary : IDiary
{
    public CharacterDiary()
    {
        
    }

    public IEnumerable<IQuest> Finished { get; } = new List<IQuest>();

    public IEnumerable<IQuest> Active { get; } = new List<IQuest>();
}
