namespace game.character.diary;

class CharacterDiary : IDiary
{
    public CharacterDiary()
    {
        Finished = new List<IQuest>();
        Active = new List<IQuest>();

        (Active as List<IQuest>).Add(new Quest());
        (Active as List<IQuest>).Add(new Quest());
    }

    public IEnumerable<IQuest> Finished { get; } 

    public IEnumerable<IQuest> Active { get; } 
}
